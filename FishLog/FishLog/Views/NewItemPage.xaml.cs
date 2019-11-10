using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FishLog.Models;

namespace FishLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Fish Fish { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Fish = new Fish
            {
                Id = Guid.NewGuid().ToString(),
                Species = "",
                Weight = 0,
                Length = 0,
                DateCaught = DateTime.Now.Date,
                TimeCaught = DateTime.Now.TimeOfDay,
                Bait = "",
                AirTemp = 0,
                WaterTemp = 0,
                Location = "",
                Depth = 0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Fish);
            await Navigation.PopModalAsync();

        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}