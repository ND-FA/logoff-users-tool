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
        private FullAppSettings _fullAppSettings;
        private CancellationTokenSource? _cancellationTokenSource;
        private readonly object _logLock = new object();

        public MainForm()
        {
            InitializeComponent();
            _sessionService = new SessionService();
            _settingsService = new SettingsService();
            _cancellationTokenSource = new CancellationTokenSource();
            _fullAppSettings = _settingsService.LoadSettings();
            
            // Clear selected servers on startup for a clean session.
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
                        AppendLog(new LogMessage("ПРОЦЕСС ОСТАНОВЛЕН ИЗ-ЗА ИЗМЕНЕНИЯ НАСТРОЕК.", LogLevel.Warning));
                    }
                    
                    _fullAppSettings = _settingsService.LoadSettings();
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
            outputRichTextBox.Clear();

            var settings = _fullAppSettings.DefaultSettings;

            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            IProgress<LogMessage> progress = new Progress<LogMessage>(update =>
            {
                lock (_logLock)
                {
                    AppendLog(update);
                }
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
                    progress.Report(new LogMessage($"КРИТИЧЕСКАЯ ОШИБКА: {ex.Message}", LogLevel.Error));
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
                AppendLog(new LogMessage("ОПЕРАЦИЯ ПРЕРВАНА ПОЛЬЗОВАТЕЛЕМ.", LogLevel.Warning));
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputRichTextBox.Clear();
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
            progress.Report(new LogMessage($"[{server}] Запуск процесса. Общее время: {settings.TimerSeconds} сек, интервал уведомлений: {settings.NotificationInterval} сек.", LogLevel.Info));

            var remaining = settings.TimerSeconds;
            while (remaining > 0)
            {
                if (token.IsCancellationRequested) return;

                if (remaining % settings.NotificationInterval == 0 || (remaining == settings.TimerSeconds && settings.TimerSeconds > 0) )
                {
                    _ = Task.Run(() =>
                    {
                        try
                        {
                            List<Session> currentSessions = _sessionService.GetActiveSessions(server, settings.ExcludedUsersEnabled, settings.ExcludedUsers);
                            if (currentSessions.Any())
                            {
                                var minutes = (int)Math.Ceiling(remaining / 60.0);
                                var formattedMessage = $"{settings.Message} (Осталось:  ~{minutes} мин.)";
                                var messageTimeout = Math.Max(1, settings.NotificationInterval - 5);

                                progress.Report(new LogMessage($"[{server}] Найдено {currentSessions.Count} активных сессий. Отправка уведомлений (отобразятся на {messageTimeout} сек)...", LogLevel.Info));

                                foreach (var session in currentSessions)
                                {
                                    try
                                    {
                                        _sessionService.SendMessage(server, session.Id, formattedMessage, messageTimeout);
                                    }
                                    catch (Exception ex)
                                    {
                                        progress.Report(new LogMessage($"[{server}] ОШИБКА отправки сообщения сессии ID {session.Id}: {ex.Message}", LogLevel.Error));
                                    }
                                }
                                progress.Report(new LogMessage($"[{server}] Уведомления отправлены.", LogLevel.Info));
                            }
                            else
                            {
                                progress.Report(new LogMessage($"[{server}] Активных сессий для уведомления не найдено.", LogLevel.Info));
                            }
                        }
                        catch (Exception ex)
                        {
                             progress.Report(new LogMessage($"[{server}] КРИТИЧЕСКАЯ ОШИБКА при отправке уведомлений: {ex.Message}", LogLevel.Error));
                        }
                    }, token);
                }

                try
                {
                    await Task.Delay(1000, token); 
                }
                catch (TaskCanceledException)
                {
                    return; // Exit if the task is cancelled
                }
                remaining--;
            }

            progress.Report(new LogMessage($"[{server}] ВРЕМЯ ИСТЕКЛО. Принудительное завершение активных сеансов...", LogLevel.Warning));

            try
            {
                var finalSessions = await Task.Run(() => _sessionService.GetActiveSessions(server, settings.ExcludedUsersEnabled, settings.ExcludedUsers), token);
                if (finalSessions.Any())
                {
                    progress.Report(new LogMessage($"[{server}] Найдено {finalSessions.Count} сессий для завершения.", LogLevel.Info));
                    foreach (var session in finalSessions)
                    {
                        try
                        {
                            progress.Report(new LogMessage($"[{server}] Завершаю сеанс ID: {session.Id}, Пользователь: {session.UserName}...", LogLevel.Info));
                            await Task.Run(() => _sessionService.LogoffSession(server, session.Id), token);
                            progress.Report(new LogMessage($"[{server}] Сеанс ID: {session.Id} УСПЕШНО ЗАВЕРШЕН.", LogLevel.Success));
                        }
                        catch (Exception ex)
                        {
                            progress.Report(new LogMessage($"[{server}] ОШИБКА завершения сеанса ID {session.Id}: {ex.Message}", LogLevel.Error));
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
                progress.Report(new LogMessage($"[{server}] КРИТИЧЕСКАЯ ОШИБКА при финальном завершении сеансов: {ex.Message}", LogLevel.Error));
            }
            
            progress.Report(new LogMessage($"[{server}] Процесс завершен.", LogLevel.Success));
        }

        private void AppendLog(LogMessage logMessage)
        {
            // Ensure UI updates are done on the UI thread
            if (outputRichTextBox.InvokeRequired)
            {
                outputRichTextBox.Invoke(new Action(() => AppendLog(logMessage)));
                return;
            }

            outputRichTextBox.SelectionStart = outputRichTextBox.TextLength;
            outputRichTextBox.SelectionLength = 0;

            Color messageColor;
            switch (logMessage.Level)
            {
                case LogLevel.Info:
                    messageColor = Color.Black;
                    break;
                case LogLevel.Warning:
                    messageColor = Color.DarkGoldenrod;
                    break;
                case LogLevel.Error:
                    messageColor = Color.Red;
                    break;
                case LogLevel.Success:
                    messageColor = Color.Green;
                    break;
                default:
                    messageColor = Color.Black;
                    break;
            }

            outputRichTextBox.SelectionColor = messageColor;
            outputRichTextBox.AppendText($"{DateTime.Now:HH:mm:ss} - {logMessage.Message}{Environment.NewLine}");
            outputRichTextBox.SelectionColor = outputRichTextBox.ForeColor;
        }
    }

    public class LogMessage
    {
        public string Message { get; }
        public LogLevel Level { get; }

        public LogMessage(string message, LogLevel level)
        {
            Message = message;
            Level = level;
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Success
    }
}
