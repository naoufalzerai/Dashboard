using Microsoft.Extensions.Configuration;
using Entities.Config;
using BL.Video;


class ExtractVideo : IService
{
    private readonly ConsoleSettings _settings;
    public ExtractVideo(IConfiguration configuration)
    {
        _settings = configuration.GetRequiredSection("Settings").Get<ConsoleSettings>();
    }

    public void DoWork()
    {
        if (_settings.ExtractVideo)
        {
            System.Console.WriteLine("Start SaveFrames();");
            VideoHelper.ExtractVideo(_settings.Folder, _settings.BinaryFolder, _settings.TemporaryFilesFolder, _settings.InputPath, _settings.OutputToFile);
        }

    }
}

