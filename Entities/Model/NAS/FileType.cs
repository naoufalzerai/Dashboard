namespace Entities.Model.NAS;

public enum FileType
{
    [Icon("bi bi-folder-fill")]
    Folder,
    
    [Icon("bi bi-modem-fill")]
    Server,

    [Icon("bi bi-file-music-fill")]
    Music,

    [Icon("bi bi-file-image-fill")]
    Photo,

    [Icon("bi bi-file-earmark-text-fill")]
    Text,

    [Icon("bi bi-file-earmark-fill")]
    Other
}

internal class IconAttribute : Attribute
{
    public IconAttribute(string icon)
    {
        _icon = icon;
    }

    public string _icon { get; }
}
public static class FileTypeExtensions
{
    public static string Icon(this FileType val)
    {
        IconAttribute[] attributes = (IconAttribute[])val.GetType()
            .GetField(val.ToString())
            .GetCustomAttributes(typeof(IconAttribute), false);
        return attributes.Length > 0 ? attributes[0]._icon : string.Empty;
    }
} 