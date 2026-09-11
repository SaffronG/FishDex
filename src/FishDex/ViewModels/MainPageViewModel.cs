using FishDex.Models;
using FishDex.Services;
using System.ComponentModel;

namespace FishDex.ViewModels;

public partial class MainPageViewModel : INotifyPropertyChanged
{
    public MainPageViewModel(IApiService apiService, INavigationService navigationService)
    {
        _apiService = apiService;
        _navigationService = navigationService;
        FishList = apiService.DebugFishList();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly IApiService _apiService;
    private readonly INavigationService _navigationService;
    public List<Fish> FishList
    {
        get;
        set
        {
            if (field != value)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FishList)));
            }
        }
    }
    private async Task LoadFishDataAsync()
    {
        var fishData = await _apiService.GetFishAsync();
        if (fishData != null)
        {
            FishList = [.. fishData];
        }
    }
    public Command LoadFishDataCommand => field ??= new Command(async () => await _apiService.GetFishAsync());
    public Command RecordCatchClickedCommand => field ??= new Command(async () =>
    {
        await _navigationService.NavigateToAsync("RecordCatch"); // navigate to the RecordCatchPage
    });
    public Command ProfileClickedCommand => field ??= new Command(async () =>
    {
        await _navigationService.NavigateToAsync("Profile"); // navigate to the RecordCatchPage
    });
    public Command FishTileClickedCommand => field ??= new Command<Fish>(async (fish) =>
    {
            await _navigationService.NavigateToAsync("Details", new Dictionary<string, object> { ["Fish"] = fish });
    });
}