using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taspinn.Services
{
    public interface IDisposalDataStore<T>
    {
        Task<bool> UpdateCountAsync(int id, int count);
        Task<bool> DeleteItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(string username, bool forceRefresh = false);
        Task<bool> MoveItemToShoppingListAsync(int id);
    }
}
