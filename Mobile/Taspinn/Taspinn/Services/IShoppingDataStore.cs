using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taspinn.Services
{
    public interface IShoppingDataStore<T>
    {
        Task<bool> UpdateItemCountAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
