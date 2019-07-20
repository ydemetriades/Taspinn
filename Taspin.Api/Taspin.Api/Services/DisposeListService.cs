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
            if (listToItemId <= 0)
                throw new ArgumentException("Id was less or equal zero", nameof(listToItemId));

            _dac.DeleteItem(listToItemId);
        }

        public DisposeList GetUserDisposeList(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username was null or white space", nameof(username));
            }

            var models = _dac.SelectDisposeList(username);

            return new DisposeList
            {
                Items = models
                        .Select(i => new DisposeList.DisposeListItem
                        {
                            BarCode = i.barcode,
                            Count = i.count,
                            DisposeListToItemId = i.objid,
                            Name = i.name,
                        })
                        .ToList()
            };
        }

        public void MoveToShoppingList(int listToItemId)
        {
            _dac.MoveItemToShoppingList(listToItemId);
        }

        public void UpdateItemCountrer(int listToItemId, int counter)
        {
            _dac.UpdateCountForItemInDisposeList(listToItemId, counter);
        }
    }
}
