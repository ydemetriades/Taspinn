using System;
using System.Threading.Tasks;
using Taspinn.Models;
using Taspinn.Services;

namespace Taspinn.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public DataStoreType DataStoreType_ { get; set; }
        public Item Item { get; set; }
        public IDisposalDataStore<Item> DisposalDataStore { get; set; }
        public IShoppingDataStore<Item> ShoppingDataStore { get; set; }

        public ItemDetailViewModel(DataStoreType dataStoreType, Item item = null)
        {
            Title = item?.Name;
            DataStoreType_ = dataStoreType;
            Item = item;
            DisposalDataStore = new MockDisposedDataStore();
            ShoppingDataStore = new MockShoppingDataStore();
        }

        public async Task<bool> UpdateCountAsync(int count)
        {
            if (count == Item.Count)
                return true;

            Item.Count = count;

            if (DataStoreType_ == DataStoreType.Disposed)
            {
                return await DisposalDataStore.UpdateCountAsync(Item.Id, count);
            }

            if (DataStoreType_ == DataStoreType.Shopping)
            {
                return await ShoppingDataStore.UpdateItemCountAsync(Item.Id, count);
            }

            return true;
        }

        public enum DataStoreType
        {
            None,
            Shopping,
            Disposed
        }
    }
}
