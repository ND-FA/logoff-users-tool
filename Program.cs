using System;
using System.Windows.Forms;
using LogoffUsersTool.Models;
using LogoffUsersTool.Services;
using LogoffUsersTool.UI;

namespace LogoffUsersTool;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        var settingsService = new SettingsService();
        var fullAppSettings = settingsService.LoadSettings();
        
        var mainForm = new MainForm();
        ThemeService.ApplyTheme(mainForm, fullAppSettings.Application.Theme);
        
        Application.Run(mainForm);
    }
}
