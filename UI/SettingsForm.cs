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

    public SettingsForm()
    {
        InitializeComponent();
        _settingsService = new SettingsService();
        _powerShellService = new PowerShellService();
        _fullAppSettings = _settingsService.LoadSettings();
        LoadDefaultSettings();
        UpdateServersListControls();
        SetupPlaceholder();
        this.serversListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.serversListBox_ItemCheck);
        this.serversListBox.SelectedIndexChanged += new System.EventHandler(this.serversListBox_SelectedIndexChanged);
    }

    private void LoadDefaultSettings()
    {
        var appSettings = _fullAppSettings.Application;
        var defaultSettings = _fullAppSettings.DefaultSettings;

        serversListBox.Items.Clear();
        var allServers = appSettings.KnownServers.Union(defaultSettings.Servers ?? new List<string>()).Distinct().ToList();
        appSettings.KnownServers = allServers;

        foreach (var server in allServers)
        {
            var isChecked = defaultSettings.Servers?.Contains(server) ?? false;
            serversListBox.Items.Add(server, isChecked);
        }

        timerNumericUpDown.Value = defaultSettings.TimerSeconds > 0 ? defaultSettings.TimerSeconds : 900;
        intervalNumericUpDown.Value = defaultSettings.NotificationInterval > 0 ? defaultSettings.NotificationInterval : 60;
        messageTextBox.Text = defaultSettings.Message;
        excludedUsersCheckBox.Checked = defaultSettings.ExcludedUsersEnabled;
        excludedUsersTextBox.Text = defaultSettings.ExcludedUsers;
        saveSettingsCheckBox.Checked = defaultSettings.SaveSettings;

        UpdateServersListControls();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var appSettings = _fullAppSettings.Application;
        var defaultSettings = _fullAppSettings.DefaultSettings;

        appSettings.KnownServers = serversListBox.Items.OfType<string>().Distinct().ToList();
        defaultSettings.Servers = serversListBox.CheckedItems.OfType<string>().ToList();

        defaultSettings.TimerSeconds = (int)timerNumericUpDown.Value;
        defaultSettings.NotificationInterval = (int)intervalNumericUpDown.Value;
        defaultSettings.Message = messageTextBox.Text;
        defaultSettings.ExcludedUsersEnabled = excludedUsersCheckBox.Checked;
        defaultSettings.ExcludedUsers = excludedUsersTextBox.Text;
        defaultSettings.SaveSettings = saveSettingsCheckBox.Checked;

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
        if (!string.IsNullOrEmpty(serverName) && !serversListBox.Items.Contains(serverName))
        {
            serversListBox.Items.Insert(0, serverName);
            serversListBox.SetItemChecked(0, true);
            _fullAppSettings.Application.ManuallyAddedServers.Add(serverName);
            newServerTextBox.Clear();
            UpdateServersListControls();
        }
    }

    private void removeServerButton_Click(object sender, EventArgs e)
    {
        if (serversListBox.SelectedItem is string selectedServer && _fullAppSettings.Application.ManuallyAddedServers.Contains(selectedServer))
        {
            serversListBox.Items.Remove(selectedServer);
            _fullAppSettings.Application.KnownServers.Remove(selectedServer);
            _fullAppSettings.Application.ManuallyAddedServers.Remove(selectedServer);
        }

        UpdateServersListControls();
    }

    private async void searchServersButton_Click(object sender, EventArgs e)
    {
        searchServersButton.Enabled = false;
        var servers = await _powerShellService.GetServersAsync();

        foreach (var server in servers)
        {
            if (!serversListBox.Items.Contains(server))
            {
                serversListBox.Items.Add(server, false);
            }
        }

        UpdateServersListControls();
        searchServersButton.Enabled = true;
    }

    private void UpdateServersListControls()
    {
        bool isListEmpty = serversListBox.Items.Count == 0;

        serversListBox.Visible = !isListEmpty;
        emptyServersListLabel.Visible = isListEmpty;
        
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
        this.BeginInvoke((MethodInvoker)UpdateServersCountLabel);
    }

    private void UpdateServersCountLabel()
    {
        var totalCount = serversListBox.Items.Count;
        var checkedCount = serversListBox.CheckedItems.Count;
        serversCountLabel.Text = totalCount > 0 ? $"({checkedCount}/{totalCount})" : "";
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
            newServerTextBox.ForeColor = SystemColors.WindowText;
        }
    }

    private void newServerTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(newServerTextBox.Text))
        {
            newServerTextBox.Text = PlaceholderText;
            newServerTextBox.ForeColor = SystemColors.GrayText;
        }
    }

    private void SetupPlaceholder()
    {
        newServerTextBox.Text = PlaceholderText;
        newServerTextBox.ForeColor = SystemColors.GrayText;
        newServerTextBox.TextChanged += newServerTextBox_TextChanged;
        newServerTextBox.Enter += newServerTextBox_Enter;
        newServerTextBox.Leave += newServerTextBox_Leave;
        addServerButton.Enabled = false;
    }
}
