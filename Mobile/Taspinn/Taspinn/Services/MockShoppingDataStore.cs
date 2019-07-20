using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taspinn.Models;

namespace Taspinn.Services
{
    public class MockShoppingDataStore : IShoppingDataStore<Item>
    {
        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.3.125:5001/api/shoppinglist")
        };

        List<Item> items = new List<Item>();

        public MockShoppingDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> UpdateItemCountAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Item/{id}");
            if(response == null)
            {
                return false;
            }
            if(response.IsSuccessCode)
            {
                var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
                items.Remove(oldItem);

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string username, bool forceRefresh = false)
        {
            if(items == null || !items.Any() || forceRefresh==true)
            {
                var response = await _httpClient.GetAsync(username);

                if(response == null)
                {
                    return items;
                }

                var content = await response.Content.ReadAsStringAsync();

                if(content == null)
                {
                    return items;
                }

                var loc_items = JsonConvert.DeserializeObject<ShoppingListModel>(content);

                if(loc_items == null)
                {
                    return items;
                }

                items = loc_items.Items.Select(x => new Item
                {
                    Id = x.DisposeListToItemId,
                    Name = x.Name,
                    Barcode = x.BarCode,
                    Count = x.Count
                });
            }

            return items;
        }
    }
}