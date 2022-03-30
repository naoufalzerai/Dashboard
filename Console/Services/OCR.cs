using Microsoft.Extensions.Configuration;
using Entities.Config;


internal class OCR : IService
{
    private readonly ConsoleSettings _settings;
    public OCR(IConfiguration configuration)
    {
        _settings = configuration.GetRequiredSection("Settings").Get<ConsoleSettings>();
    }
    public void DoWork()
    {
        if (_settings.OCR)
            throw new NotImplementedException();
    }
}
