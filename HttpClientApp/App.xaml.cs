
using HttpClientApp.Models;
using HttpClientApp.Views.AppWindows;
using HttpClientApp.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using WebServices;
using WebServices.DataModels;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;


namespace HttpClientApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    internal IHost? Host { get; private set; }
    private Frame rootFrame = new Frame();
    internal Frame RootFrame => rootFrame;
    internal Frame? NavigationFrame;
    public App()
    {
        InitializeComponent();
        
        //Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        //    .ConfigureServices((builderContext,services) =>
        //    {
        //        services
        //            .Configure<ApiClientSettings>(builderContext.Configuration.GetSection("CatApiSettings"))
        //            .AddScoped<MainWindow>()
        //            .AddScoped<MainWindowViewModel>()
        //            .AddScoped<HomePage>()
        //            .AddScoped<HomeViewModel>()
        //            .AddScoped<IBreedSearchApi, BreedSearchApi>();
        //    })
        //    .Build();
        //this.MainWindow = Host.Services.GetService<MainWindow>();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        //base.OnStartup(e);
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(e.Args)
            .ConfigureAppConfiguration((context, config) =>
            {
#if DEBUG
                config.AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: true);
#endif
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((builderContext, services) =>
            {
                services
                    .AddSingleton<MainWindow>()
                    .AddSingleton<MainWindowViewModel>()

                    .AddTransient<HomePage>()
                    .AddTransient<HomeViewModel>()

                    .AddTransient<NavigationPage>()
                    .AddTransient<NavigationViewModel>()

                    .AddSingleton<IBreedSearchApi, BreedSearchApi>()
                    .AddOptions<ApiClientOptions>()
                        .Bind(builderContext.Configuration.GetSection(ApiClientOptions.ApiClient));
            })
            .Build();
        MainWindow = Host.Services.GetRequiredService<MainWindow>()!;
        MainWindow.Content = RootFrame;
        
        if(rootFrame.Content == null)
        {
            NavigationPage navigationPage = Host.Services.GetRequiredService<NavigationPage>();
            NavigationFrame = navigationPage.NavMenuFrame;
            rootFrame.Navigate(navigationPage);
        }

        MainWindow.Show();
        
        //IServiceCollection services = new ServiceCollection()
        //    .Configure<ApiClientConfiguration>(services("CatApiSettings"))
        //    .AddScoped<MainWindow>()
        //    .AddScoped<MainWindowViewModel>()
        //    .AddScoped<HomePage>()
        //    .AddScoped<HomeViewModel>()
        //    .AddScoped<IBreedSearchApi, BreedSearchApi>();

        //ServiceProvider serviceProvider = services.BuildServiceProvider();
        //mv = serviceProvider.GetRequiredService<MainWindow>();
        //mv.Show();
    }
    protected override async void OnExit(ExitEventArgs e)
    {
       if(Host != null)
        {
            await Host.StopAsync();
            Host.Dispose();
        }
        base.OnExit(e);
    }
}

