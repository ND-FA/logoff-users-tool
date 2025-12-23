using System;
using System.Windows.Forms;
using LogoffUsersTool.Models;
using LogoffUsersTool.Services;

namespace LogoffUsersTool.UI;

public partial class SettingsForm : Form
{
    private readonly SettingsService _settingsService;
    private readonly PowerShellService _powerShellService;
    private FullAppSettings _fullAppSettings;

    public SettingsForm()
    {
        InitializeComponent();
        _settingsService = new SettingsService();
        _powerShellService = new PowerShellService();
        _fullAppSettings = _settingsService.LoadSettings();
        LoadDefaultSettings();
    }

    private void LoadDefaultSettings()
    {
        var defaultSettings = _fullAppSettings.DefaultSettings;
        serverComboBox.Text = defaultSettings.Server;
        timerNumericUpDown.Value = defaultSettings.TimerSeconds;
        intervalNumericUpDown.Value = defaultSettings.NotificationInterval;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var defaultSettings = _fullAppSettings.DefaultSettings;
        defaultSettings.Server = serverComboBox.Text;
        defaultSettings.TimerSeconds = (int)timerNumericUpDown.Value;
        defaultSettings.NotificationInterval = (int)intervalNumericUpDown.Value;
        _settingsService.SaveSettings(_fullAppSettings);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private async void searchServersButton_Click(object sender, EventArgs e)
    {
        searchServersButton.Enabled = false;
        var servers = await _powerShellService.GetServersAsync();
        serverComboBox.DataSource = servers;
        searchServersButton.Enabled = true;
    }
}
