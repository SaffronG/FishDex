using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls; // or Xamarin.Forms if your project uses that namespace

namespace FishDex
{
    public partial class MainPage : ContentPage
    {
        public List<string> FishList { get; } = ["Bass", "Trout", "Salmon", "Catfish", "Pike", "Burbot", "Rainbow Trout"];

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private void OnRecordCatchClicked(object? sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecordCatchPage());
        }
    }
}