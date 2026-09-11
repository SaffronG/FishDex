using FishDex.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishDex.ViewModels
{
    public partial class ProfilePageViewModel
    {
        
        public string name {  get; set; }


        public ProfilePageViewModel( string _name)
        {
           name = _name;
        }

        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;
    }
}
