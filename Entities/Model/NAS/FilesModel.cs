namespace Entities.Model.NAS;
public class FilesModel
{
    public bool IsSelected { get; set; }
    public string? Path { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public FileType Type
    {
        get
        {
            string[] extention = this.Name.Split('.');
            if (extention.Length < 2)
                return FileType.Other;
                
            return extention[1] switch{
                "mp3"=>FileType.Music,
                _=>FileType.Other
            };
        }
    }
}
public enum FileType
{
    [Icon("bi bi-folder-fill")]
    Folder,

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