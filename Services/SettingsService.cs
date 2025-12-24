
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
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
            var settings = JsonSerializer.Deserialize<FullAppSettings>(json) ?? new FullAppSettings();
            
            // Обратная совместимость: если есть старое поле Server, но нет нового Servers
            var jsonNode = JsonNode.Parse(json);
            var defaultSettingsNode = jsonNode?["DefaultSettings"];
            if (defaultSettingsNode?["Server"] != null && defaultSettingsNode?["Servers"] == null)
            {
                var server = defaultSettingsNode["Server"].GetValue<string>();
                if (!string.IsNullOrEmpty(server))
                {
                    settings.DefaultSettings.Servers = new List<string> { server };
                }
            }
            
            return settings;
        }
        catch (Exception)
        {
            // В случае любой ошибки (невалидный JSON и т.д.) возвращаем дефолтные настройки
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
