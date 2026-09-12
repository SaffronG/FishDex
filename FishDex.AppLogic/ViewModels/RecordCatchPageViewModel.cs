using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FishDex.AppLogic.ViewModels;

public partial class RecordCatchPageViewModel(INavigationService navservice, IPhotoStorageService photoservice) : ObservableObject
{
    public string FishNameEntry { get; set; } = "Rainbow Trout";
    public decimal FishWeightEntry { get; set; } = 3.13m;
    public decimal FishLengthEntry { get; set; } = 5.4m;
    readonly INavigationService NavHandle = navservice;
    readonly IPhotoStorageService _photoClient = photoservice;

    [ObservableProperty]
    public string fishImageSource = "fish_silhouette.png";

    [RelayCommand]
    public async Task SaveButtonClicked()
    {
        await NavHandle.DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!\nNow saving locally...", "OK");
        await _photoClient.AddImageToLocalStorage(File.OpenRead(FishImageSource), FishNameEntry);
        await NavHandle.NavigateToAsync("..");
    }

    [RelayCommand]
    public async Task CancelButtonClicked() => await NavHandle.NavigateToAsync("..");

    [RelayCommand]
    public async Task PickPhoto()
    {
        FishImageSource = await _photoClient.GetPhotoFromUser(FishNameEntry) ?? "fish_silhouette.png";
    }

    [RelayCommand]
    public async Task TakePhoto()
    {
        FishImageSource = await _photoClient.TakePhotoAsync() ?? "fish_silhouette.png";
    }
}
