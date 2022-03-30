using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        
        var IServices = AppDomain.CurrentDomain.GetAssemblies()
                                                .SelectMany(s=> s.GetTypes() )
                                                .Where(p=>p.GetInterfaces().Contains(typeof(IService)))
                                                .ToList<Type>();
            
        using IHost host = Host.
                            CreateDefaultBuilder(args).
                            ConfigureServices(services => {
                                                    IServices.
                                                        ForEach(c=>{
                                                            services.AddSingleton(c);
                                                        }
                                                        );
                            }).
                            ConfigureAppConfiguration(app =>
                            {
                                app.AddJsonFile("appsettings.json");
                            }).
                            Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        // var workerInstance = provider.GetRequiredService<OCR>();
        IServices.ForEach(c=>{
            IService workerInstance = (IService)provider.GetRequiredService(c);
            workerInstance.DoWork();
        });
        
        host.Run();
       
    }
}