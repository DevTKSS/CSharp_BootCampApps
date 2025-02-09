using HttpClientApp.Models;
using System.Windows;

namespace HttpClientApp.Views.AppWindows;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        this.DataContext = vm;
        
    }
}