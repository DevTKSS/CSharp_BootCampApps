using HttpClientApp.Models;
using System.Windows.Controls;
namespace HttpClientApp.Views.Pages;
/// <summary>
/// Interaktionslogik für HomePage.xaml
/// </summary>
public partial class HomePage : Page
{
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        this.DataContext = vm;
    }
}
