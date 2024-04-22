using System.Configuration;
using System.Data;
using System.Windows;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hashcat.ASPNET.Identity;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
#if TOOL
public partial class App
#else
public partial class App : Application
#endif
{
    private IHost _host;
    public App(){
        var hostBuilder = new HostBuilder()
            .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    //configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    //configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                    configurationBuilder.AddCommandLine(Environment.GetCommandLineArgs());
                })
                
                .ConfigureServices((context, services) =>{
                    #if !TOOL
                    services.AddSingleton<MainWindow>();
                    #endif
                });

          _host = hostBuilder.Build();
    }
#if !TOOL
    private async void Application_Startup(object sender, StartupEventArgs e){
        await _host.StartAsync();
        Console.WriteLine("Hello World");
        var mainWindow = _host.Services.GetService<MainWindow>();
        mainWindow.Show();
    }

    private async void Application_Exit(object sender, ExitEventArgs e){
        using (_host){
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
#endif
}

