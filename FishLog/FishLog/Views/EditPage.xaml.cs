using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FishLog.Models;
using FishLog.ViewModels;

namespace FishLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public Fish Fish { get; set; }
        ItemDetailViewModel viewModel;

        public EditPage(Fish fish)
        {
            InitializeComponent();
            Fish = new Fish
            {
                Id = fish.Id,
                Species = fish.Species,
                Weight = fish.Weight,
                Length = fish.Length,
                DateCaught = fish.DateCaught,
                TimeCaught = fish.TimeCaught,
                Bait = fish.Bait,
                AirTemp = fish.AirTemp,
                WaterTemp = fish.WaterTemp,
                Location = fish.Location,
                Depth = fish.Depth
            };
            viewModel = new ItemDetailViewModel(Fish);
            BindingContext = this;
        }

        async void Save_Edit_Clicked(object sender, EventArgs e)
        { 
            MessagingCenter.Send(this, "EditItem", Fish);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}