using System;
using System.Collections.Generic;

namespace Taspin.Api.Services.Dtos
{
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
