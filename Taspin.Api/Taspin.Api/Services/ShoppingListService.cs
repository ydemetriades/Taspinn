using System;
using System.Linq;
using Taspin.Data.Dac;

namespace Taspin.Api.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly ShoppingListDac _dac;

        public ShoppingListService(ShoppingListDac dac)
        {
            _dac = dac;
        }

        public ShoppingList GetUserShoppingList(string username)
        {
            var models = _dac.SelectShoppingList(username);

            return new ShoppingList
            {
                Items = models
                        .Select(i => new ShoppingList.ShoppingListItem
                        {
                            BarCode = i.barcode,
                            Count = i.count,
                            Name = i.name,
                            ShoppingListToItemId = i.objid
                        })
                        .ToList()
            };
        }

        public void DeleteItem(int listToItemId)
        {
            _dac.DeleteItem(listToItemId);
        }

        public void UpdateItemCountrer(int listToItemId, int counter)
        {
            _dac.UpdateCountForItemInShoppingList(listToItemId, counter);
        }
    }
}
