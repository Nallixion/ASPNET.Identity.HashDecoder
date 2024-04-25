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

#if TOOL   
    static Task<int> Main(string[] args)
        => new HostBuilder()
        .RunCommandLineApplicationAsync<Program>(args);

    private IHostEnvironment _env;

    public App(IHostEnvironment env){
        _env = env;
    }

    private void OnExecute(){
        var text = new WenceyWang.FIGlet.AsciiArt("ASP2hashcat");
    Console.WriteLine (text);
    }
#else 
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
#endif

#if !TOOL
    private async void Application_Startup(object sender, StartupEventArgs e){
        await _host.StartAsync();
        var hashDemoV3 = "AQAAAAEAACcQAAAAEG7xx8smhzcYFaAhPSRj1rgxfAoqKBv4WM/4R+Z0SvFxtxuMkfgBS28p1MQzvV0OeQ==";
        var asphash = new AspNetIdentityHashInfo(hashDemoV3);
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

