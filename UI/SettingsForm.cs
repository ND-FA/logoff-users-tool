using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LogoffUsersTool.Models;
using LogoffUsersTool.Services;

namespace LogoffUsersTool.UI;

public partial class SettingsForm : Form
{
    private readonly SettingsService _settingsService;
    private FullAppSettings _fullAppSettings;
    private readonly List<string> _allServers;
    private bool _isCheckingAll = false;

    public SettingsForm(List<string> allServers)
    {
        InitializeComponent();
        _settingsService = new SettingsService();
        _fullAppSettings = _settingsService.LoadSettings();
        _allServers = allServers;
        LoadDefaultSettings();
        serversCheckedListBox.ItemCheck += serversCheckedListBox_ItemCheck;
        UpdateServersListControls();
    }

    private void LoadDefaultSettings()
    {
        var defaultSettings = _fullAppSettings.DefaultSettings;

        serversCheckedListBox.Items.Clear();
        foreach (var server in _allServers)
        {
            serversCheckedListBox.Items.Add(server, defaultSettings.Servers.Contains(server));
        }

        timerNumericUpDown.Value = defaultSettings.TimerSeconds > 0 ? defaultSettings.TimerSeconds : 900;
        intervalNumericUpDown.Value = defaultSettings.NotificationInterval > 0 ? defaultSettings.NotificationInterval : 60;
        
        UpdateServersListControls();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var defaultSettings = _fullAppSettings.DefaultSettings;
        defaultSettings.Servers = serversCheckedListBox.CheckedItems.OfType<string>().ToList();
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

    private void serversCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_isCheckingAll) return;

        this.BeginInvoke((Action)(() =>
        {
            if (serversCheckedListBox.CheckedItems.Count == serversCheckedListBox.Items.Count)
            {
                toggleSelectAllCheckBox.Checked = true;
            }
            else
            {
                toggleSelectAllCheckBox.Checked = false;
            }
        }));
    }

    private void toggleSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _isCheckingAll = true;
        bool isChecked = toggleSelectAllCheckBox.Checked;
        for (int i = 0; i < serversCheckedListBox.Items.Count; i++)
        {
            serversCheckedListBox.SetItemChecked(i, isChecked);
        }
        toggleSelectAllCheckBox.Text = isChecked ? "Убрать все" : "Выбрать все";
        _isCheckingAll = false;
    }

    private void UpdateServersListControls()
    {
        bool isListEmpty = serversCheckedListBox.Items.Count == 0;

        serversCheckedListBox.Visible = !isListEmpty;
        toggleSelectAllCheckBox.Visible = !isListEmpty;
        emptyServersListLabel.Visible = isListEmpty;

        if (!isListEmpty)
        {
            if (serversCheckedListBox.CheckedItems.Count == serversCheckedListBox.Items.Count)
            {
                toggleSelectAllCheckBox.Checked = true;
            }
            else
            {
                toggleSelectAllCheckBox.Checked = false;
            }
        }
    }
}
