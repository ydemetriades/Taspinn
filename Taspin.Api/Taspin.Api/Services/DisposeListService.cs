using System;
using System.Linq;
using Taspin.Api.Services.Dtos;
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

        public void AddItem(string barcode, string username)
        {
            ServiceValidator.ValidateString(username, nameof(username));

            _dac.AddItem(barcode, username);
        }

        public void DeleteItem(int listToItemId)
        {
            ServiceValidator.ValidateGreaterThanZero(listToItemId, nameof(listToItemId));

            _dac.DeleteItem(listToItemId);
        }


        public DisposeList GetUserDisposeList(string username)
        {
            ServiceValidator.ValidateString(username, nameof(username));

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
            ServiceValidator.ValidateGreaterThanZero(listToItemId, nameof(listToItemId));

            _dac.MoveItemToShoppingList(listToItemId);
        }

        public void UpdateItemCountrer(int listToItemId, int counter)
        {
            ServiceValidator.ValidateGreaterThanZero(listToItemId, nameof(listToItemId));
            ServiceValidator.ValidateGreaterThanZero(counter, nameof(counter));

            _dac.UpdateCountForItemInDisposeList(listToItemId, counter);
        }
    }
}
