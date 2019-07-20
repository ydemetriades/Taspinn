using System;
using System.Collections.Generic;

namespace Taspin.Api.Services
{
    public interface IDisposeListService
    {
        DisposeList GetUserDisposeList(string username);
        void DeleteItem(int listToItemId);
        void MoveToShoppingList(int listToItemId);
    }

    public class DisposeList
    {
        public List<DisposeListItem> Items { get; set; }

        public class DisposeListItem
        {
            public string Name { get; set; }

            public string BarCode { get; set; }

            public int DisposeListToItemId { get; set; }

            public int Count { get; set; }
        }
    }
}
