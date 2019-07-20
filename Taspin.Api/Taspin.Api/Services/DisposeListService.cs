using System;
using System.Linq;
using Taspin.Data.Dac;

namespace Taspin.Api.Services
{
    public class DisposeListService : IDisposeListService
    {
        private readonly DisposeListDac _dac;

        public DisposeListService(DisposeListDac dac)
        {
            _dac = dac;
        }

        public void DeleteItem(int listToItemId)
        {
            _dac.DeleteItem(listToItemId);
        }

        public DisposeList GetUserDisposeList(string username)
        {
            var model = _dac.SelectDisposeList(username);

            return new DisposeList
            {
                Items = model
                        .Items
                        .Select(i => new DisposeList.DisposeListItem
                        {
                            BarCode = i.BarCode,
                            Count = i.Count,
                            DisposeListToItemId = i.DisposeListToItemId,
                            Name = i.Name,
                        })
                        .ToList()
            };
        }

        public void MoveToShoppingList(int listToItemId)
        {
            _dac.MoveItemToShoppingList(listToItemId);
        }
    }
}
