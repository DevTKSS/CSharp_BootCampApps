using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPFMvvmApp.Presentation.ViewModels;
using WPFMvvmApp.Services;

namespace WPFMvvmApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // Create a ServiceCollection and register services
        var services = new ServiceCollection()
            .AddScoped<MainWindow>()
            .AddScoped<MainWindowViewModel>()
            .AddScoped<IUserService, UserService>();
        ServiceProvider serviceProvider = services.BuildServiceProvider();

        MainWindow mv = serviceProvider.GetService<MainWindow>()!;
        mv.Show();
    }


}

