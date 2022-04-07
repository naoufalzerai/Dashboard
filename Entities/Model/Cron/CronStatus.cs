namespace Entities.Model.Cron;

public enum CronStatus
{
    [CronStatus("bi bi-folder-fill")]
    Disabled,
    
    [CronStatus("bi bi-modem-fill")]
    RunningOk,

    [CronStatus("bi bi-file-music-fill")]
    RunningError,

    [CronStatus("bi bi-file-image-fill")]
    Stopped,
}

public class CronStatusAttribute : Attribute
{
    public CronStatusAttribute(string bg)
    {
        _bg = bg;
    }

    public string _bg { get; }
}
public static class CronStatusExtensions
{
    public static string Icon(this CronStatusAttribute val)
    {
        CronStatusAttribute[] attributes = (CronStatusAttribute[])val.GetType()
            .GetField(val.ToString())
            .GetCustomAttributes(typeof(CronStatusAttribute), false);
        return attributes.Length > 0 ? attributes[0]._bg : string.Empty;
    }
} 