
using System;
using System.IO;
using System.Text.Json;
using LogoffUsersTool.Models;

namespace LogoffUsersTool.Services;

public class SettingsService
{
    private readonly string _settingsFilePath;

    public SettingsService()
    {
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        _settingsFilePath = Path.Combine(documentsPath, "settings-tool.json");
    }

    public FullAppSettings LoadSettings()
    {
        if (!File.Exists(_settingsFilePath))
        {
            return new FullAppSettings();
        }

        try
        {
            var json = File.ReadAllText(_settingsFilePath);
            return JsonSerializer.Deserialize<FullAppSettings>(json) ?? new FullAppSettings();
        }
        catch (Exception)
        {
            return new FullAppSettings();
        }
    }

    public void SaveSettings(FullAppSettings settings)
    {
        settings.Application.LastRun = DateTime.Now;
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(_settingsFilePath, json);
    }
}
