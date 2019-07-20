using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Taspinn.Models;
using Newtonsoft.Json;

namespace Taspinn.Services
{
    public class MockDisposedDataStore : IDisposalDataStore<Item>
    {
        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.xx.xx:32000/api/disposelist")
        };

        List<Item> items;

        public MockDisposedDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." , Count = 3},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description.", Count = 5 },
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

        public async Task<bool> UpdateCountAsync(Item item)
        {
            //const string = 
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            //_httpClient.PostAsync

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string username, bool forceRefresh = false)
        {
            var response = await _httpClient.GetAsync(username);

            if(response == null)
            {
                return new List<Item>();
            }

            var content = await response.Content.ReadAsStringAsync();

            if(content == null)
            {
                return new List<Item>();
            }

            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(content);
            
            return items ?? new List<Item>();
        }

        public Task<bool> MoveItemToShoppingListAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
