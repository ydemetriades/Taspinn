using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taspinn.Services
{
    public interface IShoppingDataStore<T>
    {
        Task<bool> UpdateItemCountAsync(int id, int count);
        Task<bool> DeleteItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(string username, bool forceRefresh = false);
    }
}
