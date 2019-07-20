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

        public void DeleteItem(int listToItemId)
        {
            _dac.DeleteItem(listToItemId);
        }

        ShoppingList IShoppingListService.GetUserShoppingList(string username)
        {
            var model = _dac.SelectShoppingList(username);

            return new ShoppingList
            {
                Items = model
                        .Items
                        .Select(i => new ShoppingList.ShoppingListItem
                        {
                            BarCode = i.BarCode,
                            Count = i.Count,
                            Name = i.Name,
                            ShoppingListToItemId = i.ShoppingListToItemId
                        })
                        .ToList()
            };
        }
    }
}
