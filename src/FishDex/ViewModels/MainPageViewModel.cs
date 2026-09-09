using FishDex.Models;
using FishDex.Services;
using System.ComponentModel;

namespace FishDex.ViewModels;

public partial class MainPageViewModel : INotifyPropertyChanged
{
    public MainPageViewModel(ApiService apiService)
    {
        _apiService = apiService;
        FishList = apiService.DebugFishList;
        //Dispatcher.GetForCurrentThread()?.Dispatch(async () => await LoadFishDataAsync());
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly ApiService _apiService;
    Page? NavHandle { get => Application.Current?.MainPage; }
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
        await Shell.Current.GoToAsync("RecordCatch"); // navigate to the RecordCatchPage
    });
    public Command FishTileClickedCommand => field ??= new Command<Fish>(async (fish) =>
    {
            await Shell.Current.GoToAsync("details", new Dictionary<string, object> // navigate to the FishDetailPage with the selected fish as a parameter
            {
                { "fish", fish }
            });
    });
}