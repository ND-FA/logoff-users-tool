#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogoffUsersTool.Models;
using LogoffUsersTool.Services;

namespace LogoffUsersTool.UI
{
    public partial class MainForm : Form
    {
        private readonly SessionService _sessionService;
        private readonly SettingsService _settingsService;
        private readonly LoggerService _loggerService;
        private FullAppSettings _fullAppSettings;
        private CancellationTokenSource? _cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();
            _sessionService = new SessionService();
            _settingsService = new SettingsService();
            // Pass the new TreeView to the LoggerService
            _loggerService = new LoggerService(logTreeView);
            _cancellationTokenSource = new CancellationTokenSource();
            _fullAppSettings = _settingsService.LoadSettings();
            
            ThemeService.ApplyTheme(this, _fullAppSettings.Application.Theme);

            _fullAppSettings.DefaultSettings.Servers = new List<string>();

            LoadSettings();
            UpdateStartButtonState();
            progressBar.CustomText = "";
        }

        #region Settings Management

        private void LoadSettings()
        {
            ApplyDefaultSettings();

            var appSettings = _fullAppSettings.Application;

            if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(new Point(appSettings.X, appSettings.Y))))
            {
                this.Location = new Point(appSettings.X, appSettings.Y);
            }

            if (appSettings.Width >= this.MinimumSize.Width && appSettings.Height >= this.MinimumSize.Height)
            {
                this.Width = appSettings.Width;
                this.Height = appSettings.Height;
            }
        }

        private void SaveSettings()
        {
            if (!_fullAppSettings.DefaultSettings.SaveSettings) return;

            var appSettings = _fullAppSettings.Application;
            if (WindowState == FormWindowState.Normal)
            {
                appSettings.Width = this.Width;
                appSettings.Height = this.Height;
                appSettings.X = this.Location.X;
                appSettings.Y = this.Location.Y;
            }
            else
            {
                appSettings.Width = this.RestoreBounds.Width;
                appSettings.Height = this.RestoreBounds.Height;
                appSettings.X = this.RestoreBounds.X;
                appSettings.Y = this.RestoreBounds.Y;
            }
            appSettings.LastRun = DateTime.Now;

            _settingsService.SaveSettings(_fullAppSettings);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                    {
                        _cancellationTokenSource.Cancel();
                    }
                    
                    _fullAppSettings = _settingsService.LoadSettings();
                    ThemeService.ApplyTheme(this, _fullAppSettings.Application.Theme);
                    ApplyDefaultSettings();
                }
            }
        }

        private void ApplyDefaultSettings()
        {
            var defaultSettings = _fullAppSettings.DefaultSettings;

            if (defaultSettings.Servers != null && defaultSettings.Servers.Any())
            {
                serversValueLabel.Text = string.Join(", ", defaultSettings.Servers);
            }
            else
            {
                serversValueLabel.Text = "Список пуст. Настройте параметры!";
            }

            timerValueLabel.Text = $"{defaultSettings.TimerSeconds} сек.";
            intervalValueLabel.Text = $"{defaultSettings.NotificationInterval} сек.";
            messageValueLabel.Text = defaultSettings.Message;
            excludedUsersValueLabel.Text = defaultSettings.ExcludedUsersEnabled ? defaultSettings.ExcludedUsers : "Отключено";

            UpdateStartButtonState();
        }

        #endregion

        #region UI Event Handlers

        private async void startButton_Click(object sender, EventArgs e)
        {
            var selectedServers = _fullAppSettings.DefaultSettings.Servers;
            if (selectedServers == null || !selectedServers.Any())
            {
                return;
            }

            startButton.Enabled = false;
            stopButton.Enabled = true;
            statusLabel.Text = "Выполняется...";
            // Clear the TreeView before starting
            logTreeView.Nodes.Clear();

            var settings = _fullAppSettings.DefaultSettings;

            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            IProgress<LogMessage> progress = new Progress<LogMessage>(update =>
            {
                _loggerService.Log(update);
            });

            try
            {
                var serverTasks = selectedServers.Select(server =>
                    HandleSessionResetAsync(server, settings, progress, token)
                ).ToList();
                
                var allTasks = Task.WhenAll(serverTasks);
                var progressBarTask = UpdateProgressBarAsync(settings.TimerSeconds, token, allTasks);

                await Task.WhenAll(allTasks, progressBarTask);

                if (!token.IsCancellationRequested)
                {
                    progress.Report(new LogMessage("Все операции успешно завершены.", LogLevel.Success));
                }
            }
            catch (OperationCanceledException)
            {
                // User cancellation message is handled in stopButton_Click
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested) 
                {
                    progress.Report(new LogMessage($"Критическая ошибка: {ex.Message}", LogLevel.Error));
                }
            }
            finally
            {
                stopButton.Enabled = false;
                UpdateStartButtonState();
                statusLabel.Text = "Готово";
                progressBar.Value = 0;
                progressBar.CustomText = "";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
                _loggerService.Log(new LogMessage("Операция прервана пользователем.", LogLevel.Warning));
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the TreeView
            logTreeView.Nodes.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        #endregion

        private void UpdateStartButtonState()
        {
            bool isProcessRunning = stopButton.Enabled;
            bool hasServers = _fullAppSettings.DefaultSettings.Servers != null && _fullAppSettings.DefaultSettings.Servers.Any();
            startButton.Enabled = !isProcessRunning && hasServers;
        }

        private async Task UpdateProgressBarAsync(int totalSeconds, CancellationToken token, Task allTasks)
        {
            progressBar.Maximum = totalSeconds;
            progressBar.Value = 0;

            for (int i = 0; i <= totalSeconds; i++)
            {
                if (token.IsCancellationRequested || allTasks.IsCompleted)
                {
                    break;
                }
                
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() => {
                        progressBar.Value = i;
                        var remainingTime = TimeSpan.FromSeconds(totalSeconds - i);
                        progressBar.CustomText = $"Осталось: {remainingTime:mm\\:ss}";
                    }));
                }
                else
                {
                    progressBar.Value = i;
                    var remainingTime = TimeSpan.FromSeconds(totalSeconds - i);
                    progressBar.CustomText = $"Осталось: {remainingTime:mm\\:ss}";
                }

                try
                {
                    await Task.Delay(1000, token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }

            if (!token.IsCancellationRequested)
            {
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() => {
                        progressBar.Value = totalSeconds;
                        progressBar.CustomText = "Завершено";
                    }));
                }
                else
                {
                    progressBar.Value = totalSeconds;
                    progressBar.CustomText = "Завершено";
                }
            }
        }

        private async Task HandleSessionResetAsync(string server, AppSettings settings, IProgress<LogMessage> progress, CancellationToken token)
        {
            progress.Report(new LogMessage($"[{server}] Запуск. Таймер: {settings.TimerSeconds}с, Интервал: {settings.NotificationInterval}с.", LogLevel.Info));

            var remaining = settings.TimerSeconds;
            while (remaining > 0)
            {
                if (token.IsCancellationRequested) return;

                if (remaining % settings.NotificationInterval == 0 || (remaining == settings.TimerSeconds && settings.TimerSeconds > 0))
                {
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            List<Session> sessions = await Task.Run(() => _sessionService.GetActiveSessions(server, settings.ExcludedUsersEnabled, settings.ExcludedUsers));
                            if (sessions.Any())
                            {
                                var minutes = (int)Math.Ceiling(remaining / 60.0);
                                var message = $"{settings.Message} (Осталось: ~{minutes} мин.)";
                                var timeout = Math.Max(1, settings.NotificationInterval - 5);

                                progress.Report(new LogMessage($"[{server}] Найдено {sessions.Count} сессий. Отправка уведомлений (таймаут {timeout}с).", LogLevel.Info));

                                foreach (var session in sessions)
                                {
                                    try
                                    {
                                        await Task.Run(() => _sessionService.SendMessage(server, session.Id, message, timeout));
                                    }
                                    catch (Exception ex)
                                    {
                                        progress.Report(new LogMessage($"[{server}] Не удалось отправить сообщение сессии {session.Id}: {ex.Message}", LogLevel.Error));
                                    }
                                }
                                progress.Report(new LogMessage($"[{server}] Уведомления отправлены.", LogLevel.Info));
                            }
                            else
                            {
                                progress.Report(new LogMessage($"[{server}] Активных сессий не найдено.", LogLevel.Info));
                            }
                        }
                        catch (Exception ex)
                        {
                             progress.Report(new LogMessage($"[{server}] Ошибка при отправке уведомлений: {ex.Message}", LogLevel.Error));
                        }
                    }, token);
                }

                try
                {
                    await Task.Delay(1000, token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
                remaining--;
            }

            progress.Report(new LogMessage($"[{server}] Время истекло. Завершение сеансов...", LogLevel.Warning));

            try
            {
                var sessionsToLogoff = await Task.Run(() => _sessionService.GetActiveSessions(server, settings.ExcludedUsersEnabled, settings.ExcludedUsers), token);
                if (sessionsToLogoff.Any())
                {
                    progress.Report(new LogMessage($"[{server}] Найдено {sessionsToLogoff.Count} сессий для завершения.", LogLevel.Info));
                    foreach (var session in sessionsToLogoff)
                    {
                        try
                        {
                            progress.Report(new LogMessage($"[{server}] Завершение сеанса ID: {session.Id} ({session.UserName})...", LogLevel.Info));
                            await Task.Run(() => _sessionService.LogoffSession(server, session.Id), token);
                            progress.Report(new LogMessage($"[{server}] Сеанс ID: {session.Id} ({session.UserName}) завершен.", LogLevel.Success));
                        }
                        catch (Exception ex)
                        {
                            progress.Report(new LogMessage($"[{server}] Не удалось завершить сеанс ID {session.Id}: {ex.Message}", LogLevel.Error));
                        }
                    }
                }
                else
                {
                    progress.Report(new LogMessage($"[{server}] Активных сессий для завершения не найдено.", LogLevel.Info));
                }
            }
            catch (Exception ex)
            {
                progress.Report(new LogMessage($"[{server}] Ошибка при завершении сеансов: {ex.Message}", LogLevel.Error));
            }
            
            progress.Report(new LogMessage($"[{server}] Процесс завершен.", LogLevel.Success));
        }
    }
}
