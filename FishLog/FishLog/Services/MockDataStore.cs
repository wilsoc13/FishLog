using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishLog.Models;

namespace FishLog.Services
{
    public class MockDataStore : IDataStore<Fish>
    {
        List<Fish> items;

        public MockDataStore()
        {
            items = new List<Fish>();
            var mockItems = new List<Fish>
            {
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Pike", Length=24 , Weight=12},
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Bass",Length=24 , Weight=12},
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Trout", Length=24 , Weight=12},
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Walleye",Length=24 , Weight=12},
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Guppy", Length=24 , Weight=12},
                new Fish { Id = Guid.NewGuid().ToString(), Species = "Rookus (Sucker)", Length=24 , Weight=12},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Fish item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Fish item)
        {
            var oldItem = items.Where((Fish arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Fish arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Fish> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Fish>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}