using System;

using FishLog.Models;
using FishLog.Views;
using Xamarin.Forms;

namespace FishLog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Fish Fish { get; set; }

        public ItemDetailViewModel(Fish fish = null)
        {
            Title = fish?.Species;
            Fish = fish;
        }
    }
}
