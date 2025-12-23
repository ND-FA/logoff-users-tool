
namespace LogoffUsersTool.Models;

public class AppSettings
{
    public string Server { get; set; } = "test";
    public int TimerSeconds { get; set; } = 900;
    public int NotificationInterval { get; set; } = 60;
    public string Message { get; set; } = "Все сеансы на данном сервере будут завершены. Сохраните документы и выйдите из системы!";
}
