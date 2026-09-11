using System.ComponentModel;
using FishDex.Models;
using FishDex.Services;

namespace FishDex.ViewModels;

public class FishDetailPageViewModel(INavigationService navservice, Fish fish) : INotifyPropertyChanged
{
    public readonly INavigationService navHandle = navservice;
    public string Name { get; set; } = fish.Name;
    public string Weight { get; set; } = $"Weight: {fish.Weight} lbs";
    public string Length { get; set; } = $"Length: {fish.Length} inches";
    public string TimeCaught { get; set; } = $"Time Caught: {fish.TimeCaught}";
    public string Notes { get; set; } = fish.Notes ?? "No notes available. \nWould you like to add some?";
    public event PropertyChangedEventHandler? PropertyChanged;
    public Command CloseDetailModalCommand => field ??= new(async () =>
    {
        await navHandle.NavigateToAsync(".."); // basically a "back" navigation to close the modal
    });
}
