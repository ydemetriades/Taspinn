using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taspinn.Services
{
    public interface IDisposalDataStore<T>
    {
        Task<bool> UpdateCountAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(string username, bool forceRefresh = false);
        Task<bool> MoveItemToShoppingListAsync(bool forceRefresh = false);
    }
}
