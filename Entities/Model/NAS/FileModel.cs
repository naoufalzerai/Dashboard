namespace Entities.Model.NAS;
public class FileModel
{
    public bool IsSelected { get; set; }
    public bool IsFolder { get; set; }
    public bool IsServer { get; set; }
    public string? Path { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public FileType Type
    {
        get
        {
            if (this.IsFolder) return FileType.Folder;
            if (this.IsServer) return FileType.Server;
            
            string[] extention = this.Name.Split('.');
            if (extention.Length < 2)
                return FileType.Other;
                
            return extention[1] switch{
                "mp3"=>FileType.Music,
                _=> FileType.Other
            };
        }
    }
}
