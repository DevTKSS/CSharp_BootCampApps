using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WPFMvvmApp.Services;

namespace WPFMvvmApp.Presentation.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private readonly IUserService _service;
    
    public ObservableCollection<string> Usernames { get; private set; } = new ObservableCollection<string>();

    public MainWindowViewModel(
        IUserService service)
    {
        this._service = service;
        foreach (var user in service.GetUsers())
        {
            Usernames.Add(user);
        }
    }
}
