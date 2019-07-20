using System;
using System.Collections.Generic;

namespace Taspin.Api.Services
{
    public interface IShoppingListService
    {
        ShoppingList GetUserShoppingList(string username);
        void DeleteItem(int listToItemId);
        void UpdateItemCountrer(int listToItemId, int counter);
    }

    public class ShoppingList
    {
        public List<ShoppingListItem> Items { get; set; }

        public class ShoppingListItem
        {
            public string Name { get; set; }

            public string BarCode { get; set; }

            public int ShoppingListToItemId { get; set; }

            public int Count { get; set; }
        }
    }
}
