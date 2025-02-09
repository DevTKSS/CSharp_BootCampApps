using CommunityToolkit.Mvvm.ComponentModel;
using HttpClientApp.Views.Pages;
using System.Collections.ObjectModel;
using Models;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.Input;

namespace HttpClientApp.Models;
public sealed partial class NavigationViewModel : ObservableObject
{
    public NavigationViewModel()
    {
        NavigationItems = new ObservableCollection<NavigationItem>
        {
            new NavigationItem(DisplayName: "Home", PageType:typeof(HomePage)),
            new NavigationItem (DisplayName : "Favorites", PageType : typeof(FavoritesPage))
        };
        selectedItem = NavigationItems[0];
    }

    public ObservableCollection<NavigationItem> NavigationItems { get; }

    [ObservableProperty]
    private NavigationItem selectedItem;

    [RelayCommand(FlowExceptionsToTaskScheduler =true,IncludeCancelCommand =true)]
    private Task Navigate(object? parameter, CancellationToken ctk = default)
    {
        Console.WriteLine();
    }
}
