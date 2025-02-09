using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HttpClientApp.Models;
public sealed partial  class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string headline;

    public MainWindowViewModel()
    {
        Headline = "HTTP Client App";
    }

}
