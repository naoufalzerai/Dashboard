namespace Entities.Configuration;
public class ConsoleSettings
{
    public bool ExtractVideo { get; set; }
    public bool RemoveDuplicate { get; set; }
    public bool OCR { get; set; }
    public string? Folder { get; set; }
    public string? BinaryFolder { get; set; }
    public string? TemporaryFilesFolder { get; set; }
    public string? InputPath { get; set; }
    public string? OutputToFile { get; set; }
}
