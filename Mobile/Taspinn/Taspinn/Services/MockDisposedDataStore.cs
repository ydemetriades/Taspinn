using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Taspinn.Models;
using Newtonsoft.Json;
using Taspin.Api.Services.Dtos;

namespace Taspinn.Services
{
    public class MockDisposedDataStore : IDisposalDataStore<Item>
    {
        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.0.15:35001/api/DisposeList/")
            //BaseAddress = new Uri("http://127.0.0.1:35001/api/DisposeList/")
        };

        List<Item> items;

        public MockDisposedDataStore()
        {
            items = new List<Item>();
            //var mockItems = new List<Item>
            //{
            //    new Item { Id = 1, Name = "First item", Description="This is an item description." , Count = 3},
            //    new Item { Id = 2, Name = "Second item", Description="This is an item description.", Count = 5 },
            //    new Item { Id = 3, Name = "Third item", Description="This is an item description." },
            //    new Item { Id = 4, Name = "Fourth item", Description="This is an item description." },
            //    new Item { Id = 5, Name = "Fifth item", Description="This is an item description." },
            //    new Item { Id = 6, Name = "Sixth item", Description="This is an item description." }
            //};

            //foreach (var item in mockItems)
            //{
            //    items.Add(item);
            //}
        }

        public async Task<bool> UpdateCountAsync(int id, int count)
        {

            var response = await _httpClient.PutAsync($"Item/{id}/Count/{count}", null);
            if (response == null)
            {
                return false;
            }
            if (response.IsSuccessStatusCode)
            {
                var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
                oldItem.Count = count;

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Item/{id}");
            if(response == null)
            {
                return false;
            }
            if(response.IsSuccessStatusCode)
            {
                var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
                items.Remove(oldItem);

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string username, bool forceRefresh = false)
        {
            if (items == null || !items.Any() || forceRefresh == true)
            {
                var response = await _httpClient.GetAsync($"{username}");

                if (response == null)
                {
                    return items;
                }

                var content = await response.Content.ReadAsStringAsync();

                if (content == null)
                {
                    return items;
                }

                var list = JsonConvert.DeserializeObject<DisposeList>(content);
                var loc_items = list.Items;

                if (loc_items == null)
                {
                    return items;
                }

                items = loc_items.Select(x => new Item
                {
                    Id = x.DisposeListToItemId,
                    Name = x.Name,
                    Barcode = x.BarCode,
                    Count = x.Count
                }).ToList();
            }

            return items;
        }

        public async Task<bool> MoveItemToShoppingListAsync(int id)
        {
            var response = await _httpClient.PutAsync($"Item/Move/ShoppingList/{id}", null);

            if (response == null)
            {
                return false;
            }

            if (response.IsSuccessStatusCode)
            {
                var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
                items.Remove(oldItem);

                return true;
            }

            return false;
        }
    }
}
