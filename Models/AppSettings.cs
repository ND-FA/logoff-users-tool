using System.Collections.Generic;

namespace LogoffUsersTool.Models;

public class AppSettings
{
    public List<string> Servers { get; set; } = new List<string>();
    public int TimerSeconds { get; set; } = 900;
    public int NotificationInterval { get; set; } = 60;
    public string Message { get; set; } = "Все сеансы на данном сервере будут завершены. Сохраните документы и выйдите из системы!";
    public bool ExcludedUsersEnabled { get; set; } = true;
    public string ExcludedUsers { get; set; } = "adm.";
    public bool SaveSettings { get; set; } = true;
}
