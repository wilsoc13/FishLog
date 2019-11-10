using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FishLog.Models;
using FishLog.Views;

namespace FishLog.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Fish> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Fish>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Fish>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Fish;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<EditPage, Fish>(this, "EditItem", (obj, item) =>
            {
                var newItem = item as Fish;
                foreach (var fish in Items)
                {
                    if (fish.Id == item.Id)
                    {
                        fish.Species = newItem.Species;
                        fish.Weight = newItem.Weight;
                        fish.Length = newItem.Length;
                        fish.DateCaught = newItem.DateCaught;
                        fish.TimeCaught = newItem.TimeCaught;
                        fish.Bait = newItem.Bait;
                        fish.AirTemp = newItem.AirTemp;
                        fish.WaterTemp = newItem.WaterTemp;
                        fish.Location = newItem.Location;
                        fish.Depth = newItem.Depth;
                        break;
                    }
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}