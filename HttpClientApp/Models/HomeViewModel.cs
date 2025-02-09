using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WebServices.DataModels;
using WebServices;

namespace HttpClientApp.Models;
public sealed partial class HomeViewModel : ObservableObject
{
    //private static readonly string apiKey = "live_LdmQMsQCj0yKI4WlPZOmbksEq1NZRm311tG4cMPVyI9Fr6ita4Lza8KLN6vGnG5g";
    private readonly IBreedSearchApi _breedSearchClient;
    
    [ObservableProperty]
    private int limit = 1;

    [ObservableProperty]
    private int page = 0;

    public ObservableCollection<Breed> Breeds { get; }  

    public HomeViewModel(
        IBreedSearchApi breedSearchClient)
    {
        _breedSearchClient = breedSearchClient;
        Breeds = new ObservableCollection<Breed>();     
    }

    [RelayCommand(FlowExceptionsToTaskScheduler = true)]
    private async Task GetBreedsAsync()
    {
               
        var breeds = await _breedSearchClient.GetBreeds(Limit,Page);
        if (breeds.Any())
        {
            foreach (var breed in breeds)
            {
                Breeds.Add(breed);
            }
        }
    }
    
}
