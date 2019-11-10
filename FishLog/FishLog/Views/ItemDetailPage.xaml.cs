using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FishLog.Models;
using FishLog.ViewModels;

namespace FishLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Fish
            {
                Id = Guid.NewGuid().ToString(),
                Species = "Species name",
                Weight = 20.0,
                Length = 36,
                DateCaught = DateTime.Now.Date,
                TimeCaught = DateTime.Now.TimeOfDay,
                Bait = "FireTiger Rapala",
                AirTemp = 70,
                WaterTemp = 63,
                Location = "Bass Lake",
                Depth = 13
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditPage(viewModel.Fish)));
        }
    }
}