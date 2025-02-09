using HttpClientApp.Models;
using System.Windows.Controls;
using Windows.UI.Popups;

namespace HttpClientApp.Views.Pages;
/// <summary>
/// Interaktionslogik für NavigationPage.xaml
/// </summary>
public partial class NavigationPage : Page
{
    public NavigationPage(NavigationViewModel vm)
    {
        InitializeComponent();
        this.DataContext = vm;
        this.NavMenuFrame.CommandBindings.Add(((NavigationViewModel)this.DataContext).NavigateCommand);
    }

    private async void NavigationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        sender.ToString();
        e.Source.ToString();

        //NavMenuFrame.Navigate()
    }
}
