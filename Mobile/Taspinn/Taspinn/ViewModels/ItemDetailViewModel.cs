using System;
using System.Threading.Tasks;
using Taspinn.Models;

namespace Taspinn.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }

        public async Task<bool> UpdateCountAsync(int count)
        {
            Item.Count = count;
            return true;
        }
    }
}
