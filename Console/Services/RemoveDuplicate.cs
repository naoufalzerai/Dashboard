using Microsoft.Extensions.Configuration;
using Entities.Configuration;
using BL.Video;


class RemoveDuplicate : IService
{
    private readonly ConsoleSettings _settings;
    public RemoveDuplicate(IConfiguration configuration)
    {
        _settings = configuration.GetRequiredSection("Settings").Get<ConsoleSettings>();
    }

    public void DoWork()
    {
        if (_settings.RemoveDuplicate)
        {
            System.Console.WriteLine("Start Remove();");
            VideoHelper.Remove(_settings.Folder??"");
        }

    }
}
