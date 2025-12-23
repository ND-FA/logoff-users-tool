namespace LogoffUsersTool.Models;

public class FullAppSettings
{
    public AppSettings DefaultSettings { get; set; } = new();
    public AppSettings LastUsedSettings { get; set; } = new();
    public ApplicationSettings Application { get; set; } = new();
}
