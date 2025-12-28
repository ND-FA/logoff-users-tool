using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LogoffUsersTool.Models;
using LogoffUsersTool.Services;

namespace LogoffUsersTool.UI;

public partial class SettingsForm : Form
{
    private readonly SettingsService _settingsService;
    private readonly PowerShellService _powerShellService;
    private FullAppSettings _fullAppSettings;
    private const string PlaceholderText = "Добавьте сервер или нажмите поиск...";
    private ComboBox themeComboBox;
    private TextBox serverFilterTextBox;

    public SettingsForm()
    {
        InitializeComponent();
        this.serversListBox.CheckOnClick = true;
        InitializeCustomControls();

        _settingsService = new SettingsService();
        _powerShellService = new PowerShellService();
        _fullAppSettings = _settingsService.LoadSettings();
        
        ThemeService.ApplyTheme(this, _fullAppSettings.Application.Theme);
        
        LoadDefaultSettings();
        UpdateServersListControls();
        SetupPlaceholder();

        this.serversListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.serversListBox_ItemCheck);
        this.serversListBox.SelectedIndexChanged += new System.EventHandler(this.serversListBox_SelectedIndexChanged);
    }

    private void InitializeCustomControls()
    {
        InitializeThemeControls();
        InitializeFilterControls();
    }

    private void InitializeFilterControls()
    {
        this.serverFilterTextBox = new TextBox
        {
            Name = "serverFilterTextBox",
            Size = new Size(serversListBox.Width, 23),
            Location = new Point(serversListBox.Left, serversListBox.Top),
            PlaceholderText = "Фильтр...",
            Anchor = serversListBox.Anchor
        };
        this.serverFilterTextBox.TextChanged += new EventHandler(serverFilterTextBox_TextChanged);

        const int verticalShift = 28; 
        serversListBox.Top += verticalShift;
        serversListBox.Height -= verticalShift;
        serversCountLabel.Top += verticalShift;
        emptyServersListLabel.Top += verticalShift;

        if (serversListBox.Parent != null)
        {
            serversListBox.Parent.Controls.Add(this.serverFilterTextBox);
        }
        else
        {
            this.Controls.Add(this.serverFilterTextBox);
        }
    }

    private void serverFilterTextBox_TextChanged(object sender, EventArgs e)
    {
        var filterText = serverFilterTextBox.Text.ToLowerInvariant();

        serversListBox.BeginUpdate();
        serversListBox.Items.Clear();

        var filteredServers = _fullAppSettings.Application.KnownServers
            .Where(server => server.ToLowerInvariant().Contains(filterText))
            .ToList();

        foreach (var server in filteredServers)
        {
            bool isChecked = _fullAppSettings.DefaultSettings.Servers.Contains(server);
            serversListBox.Items.Add(server, isChecked);
        }

        serversListBox.EndUpdate();
        UpdateServersCountLabel();
    }

    private void InitializeThemeControls()
    {
        var saveButton = this.Controls.Find("saveButton", true).FirstOrDefault();
        if (saveButton == null) return;

        const int rightPadding = 15;
        const int internalPadding = 5;

        this.themeComboBox = new ComboBox();
        this.themeComboBox.Name = "themeComboBox";
        this.themeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.themeComboBox.Size = new System.Drawing.Size(130, 23);
        this.themeComboBox.Items.AddRange(new object[] { "Light", "Dark" });
        this.themeComboBox.SelectedIndexChanged += new EventHandler(this.themeComboBox_SelectedIndexChanged);
        
        var themeLabel = new Label();
        themeLabel.Name = "themeLabel";
        themeLabel.Text = "Тема:";
        themeLabel.AutoSize = true;

        this.themeComboBox.Location = new Point(
            saveButton.Left - this.themeComboBox.Width - rightPadding,
            saveButton.Top
        );

        themeLabel.Location = new Point(
            this.themeComboBox.Left - themeLabel.PreferredWidth - internalPadding,
            this.themeComboBox.Top + (this.themeComboBox.Height - themeLabel.Height) / 2
        );

        this.Controls.Add(themeLabel);
        this.Controls.Add(this.themeComboBox);
    }

    private void themeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedTheme = this.themeComboBox.SelectedItem?.ToString() ?? "Light";
        _fullAppSettings.Application.Theme = selectedTheme;
        ThemeService.ApplyTheme(this, selectedTheme);
        newServerTextBox_Leave(newServerTextBox, EventArgs.Empty);
    }

    private void LoadDefaultSettings()
    {
        var appSettings = _fullAppSettings.Application;
        var defaultSettings = _fullAppSettings.DefaultSettings;

        if (!defaultSettings.SaveSettings)
        {
            defaultSettings.Servers.Clear();
        }

        appSettings.KnownServers = appSettings.KnownServers.Union(defaultSettings.Servers ?? new List<string>()).Distinct().ToList();
        
        serverFilterTextBox_TextChanged(this, EventArgs.Empty);

        timerNumericUpDown.Value = defaultSettings.TimerSeconds > 0 ? defaultSettings.TimerSeconds : 900;
        intervalNumericUpDown.Value = defaultSettings.NotificationInterval > 0 ? defaultSettings.NotificationInterval : 60;
        messageTextBox.Text = defaultSettings.Message;
        excludedUsersCheckBox.Checked = defaultSettings.ExcludedUsersEnabled;
        excludedUsersTextBox.Text = defaultSettings.ExcludedUsers;
        saveSettingsCheckBox.Checked = defaultSettings.SaveSettings;

        if (this.themeComboBox != null)
        {
            this.themeComboBox.SelectedItem = appSettings.Theme ?? "Light";
        }

        UpdateServersListControls();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (!_fullAppSettings.DefaultSettings.Servers.Any())
        {
            MessageBox.Show(this, "Список выбранных серверов не может быть пустым. Пожалуйста, выберите хотя бы один сервер.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var appSettings = _fullAppSettings.Application;
        var defaultSettings = _fullAppSettings.DefaultSettings;

        appSettings.KnownServers = _fullAppSettings.Application.KnownServers.Distinct().ToList();
        defaultSettings.Servers = _fullAppSettings.DefaultSettings.Servers.Distinct().ToList();

        defaultSettings.TimerSeconds = (int)timerNumericUpDown.Value;
        defaultSettings.NotificationInterval = (int)intervalNumericUpDown.Value;
        defaultSettings.Message = messageTextBox.Text;
        defaultSettings.ExcludedUsersEnabled = excludedUsersCheckBox.Checked;
        defaultSettings.ExcludedUsers = excludedUsersTextBox.Text;
        defaultSettings.SaveSettings = saveSettingsCheckBox.Checked;
        
        if (this.themeComboBox != null)
        {
            appSettings.Theme = this.themeComboBox.SelectedItem?.ToString() ?? "Light";
        }

        _settingsService.SaveSettings(_fullAppSettings);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void addServerButton_Click(object sender, EventArgs e)
    {
        var serverName = newServerTextBox.Text.Trim();
        if (!string.IsNullOrEmpty(serverName) && !_fullAppSettings.Application.KnownServers.Contains(serverName))
        {
            _fullAppSettings.Application.KnownServers.Insert(0, serverName);
            if (!_fullAppSettings.DefaultSettings.Servers.Contains(serverName)) _fullAppSettings.DefaultSettings.Servers.Add(serverName);
            if (!_fullAppSettings.Application.ManuallyAddedServers.Contains(serverName)) _fullAppSettings.Application.ManuallyAddedServers.Add(serverName);
            
            serverFilterTextBox_TextChanged(this, EventArgs.Empty);
            newServerTextBox.Clear();
            UpdateServersListControls();
        }
    }

    private void removeServerButton_Click(object sender, EventArgs e)
    {
        if (serversListBox.SelectedItem is string selectedServer && _fullAppSettings.Application.ManuallyAddedServers.Contains(selectedServer))
        {
            _fullAppSettings.Application.KnownServers.Remove(selectedServer);
            _fullAppSettings.DefaultSettings.Servers.Remove(selectedServer);
            _fullAppSettings.Application.ManuallyAddedServers.Remove(selectedServer);
            serverFilterTextBox_TextChanged(this, EventArgs.Empty);
        }

        UpdateServersListControls();
    }

    private async void searchServersButton_Click(object sender, EventArgs e)
    {
        searchServersButton.Enabled = false;
        var servers = await _powerShellService.GetServersAsync();
        var newServersFound = false;

        foreach (var server in servers)
        {
            if (!_fullAppSettings.Application.KnownServers.Contains(server))
            {
                _fullAppSettings.Application.KnownServers.Add(server);
                newServersFound = true;
            }
        }

        if (newServersFound)
        {
            serverFilterTextBox_TextChanged(this, EventArgs.Empty);
        }

        UpdateServersListControls();
        searchServersButton.Enabled = true;
    }

    private void UpdateServersListControls()
    {
        bool isMasterListEmpty = !_fullAppSettings.Application.KnownServers.Any();

        serversListBox.Visible = !isMasterListEmpty;
        emptyServersListLabel.Visible = isMasterListEmpty;
        if (serverFilterTextBox != null) serverFilterTextBox.Enabled = !isMasterListEmpty;
        
        bool isManuallyAdded = false;
        if (serversListBox.SelectedItem is string selectedServer)
        {
            isManuallyAdded = _fullAppSettings.Application.ManuallyAddedServers.Contains(selectedServer);
        }
        removeServerButton.Enabled = isManuallyAdded;

        UpdateServersCountLabel();
    }

    private void serversListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateServersListControls();
    }

    private void serversListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index >= 0 && e.Index < serversListBox.Items.Count)
        {
            string server = serversListBox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                if (!_fullAppSettings.DefaultSettings.Servers.Contains(server))
                {
                    _fullAppSettings.DefaultSettings.Servers.Add(server);
                }
            }
            else
            {
                _fullAppSettings.DefaultSettings.Servers.Remove(server);
            }
        }

        this.BeginInvoke((MethodInvoker)UpdateServersCountLabel);
    }

    private void UpdateServersCountLabel()
    {
        var totalVisibleCount = serversListBox.Items.Count;
        var checkedCount = _fullAppSettings.DefaultSettings.Servers.Count(s => serversListBox.Items.Contains(s));
        var totalKnownCount = _fullAppSettings.Application.KnownServers.Count;

        if (totalKnownCount > 0)
        {
             serversCountLabel.Text = serverFilterTextBox.Text.Length > 0 
                ? $"({checkedCount}/{totalVisibleCount} из {totalKnownCount})" 
                : $"({checkedCount}/{totalKnownCount})";
        }
        else
        {
            serversCountLabel.Text = "";
        }
    }

    private void resetSettingsButton_Click(object sender, EventArgs e)
    {
        _fullAppSettings.DefaultSettings = new AppSettings();
        _fullAppSettings.Application.KnownServers = new List<string>();
        _fullAppSettings.Application.ManuallyAddedServers = new List<string>();
        LoadDefaultSettings();
    }

    private void newServerTextBox_TextChanged(object sender, EventArgs e)
    {
        addServerButton.Enabled = !string.IsNullOrWhiteSpace(newServerTextBox.Text) && newServerTextBox.Text != PlaceholderText;
    }

    private void newServerTextBox_Enter(object sender, EventArgs e)
    {
        if (newServerTextBox.Text == PlaceholderText)
        {
            newServerTextBox.Text = "";
            newServerTextBox.ForeColor = ThemeService.ForeColor;
        }
    }

    private void newServerTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(newServerTextBox.Text))
        {
            newServerTextBox.Text = PlaceholderText;
            newServerTextBox.ForeColor = Color.Gray;
        }
    }

    private void SetupPlaceholder()
    {
        newServerTextBox.TextChanged -= newServerTextBox_TextChanged;
        newServerTextBox.Enter -= newServerTextBox_Enter;
        newServerTextBox.Leave -= newServerTextBox_Leave;

        newServerTextBox_Leave(newServerTextBox, EventArgs.Empty);

        newServerTextBox.TextChanged += newServerTextBox_TextChanged;
        newServerTextBox.Enter += newServerTextBox_Enter;
        newServerTextBox.Leave += newServerTextBox_Leave;
        
        addServerButton.Enabled = false;
    }
}
