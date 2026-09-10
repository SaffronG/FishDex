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
        if (NavHandle != null)
            await NavHandle.Navigation.PushModalAsync(new RecordCatchPage());
    });
    public Command FishTileClickedCommand => field ??= new Command<Fish>(async (fish) =>
    {
        if (NavHandle != null)
            await NavHandle.Navigation.PushModalAsync(new FishDetailPage(fish));
    });
}