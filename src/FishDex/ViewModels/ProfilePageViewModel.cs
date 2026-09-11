using FishDex.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FishDex.ViewModels
{
    public partial class ProfilePageViewModel(INavigationService navigationService) :INotifyPropertyChanged
    {
        //private readonly IApiService _apiService;

        private readonly INavigationService _navigationService = navigationService;

        public Command OnToHomeClickedCommand => field ??= 
            new Command(async () => await _navigationService.NavigateToAsync(".."));
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
