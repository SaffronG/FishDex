using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FishDex.AppLogic.ViewModels;

public partial class MainPageViewModel(IApiService _apiService, INavigationService _navigationService) : ObservableObject
{
    [ObservableProperty]
    private List<Fish> fishList = [];
    [RelayCommand]
    private async Task LoadFishData()
    {
        var fishData = await _apiService.GetFishAsync();
        if (fishData != null) FishList = [.. fishData];
    }

    [RelayCommand]
    public async Task RecordCatchClicked() => await _navigationService.NavigateToAsync("RecordCatch");

    [RelayCommand]
    public async Task FishTileClicked(Fish fish) => await _navigationService.NavigateToAsync("Details", new Dictionary<string, object> { ["Fish"] = fish });
}