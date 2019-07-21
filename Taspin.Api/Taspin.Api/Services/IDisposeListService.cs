using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Services
{
    public interface IDisposeListService
    {
        void AddItem(int barcode, string username);
        DisposeList GetUserDisposeList(string username);
        void DeleteItem(int listToItemId);
        void MoveToShoppingList(int listToItemId);
        void UpdateItemCountrer(int listToItemId, int counter);
    }

    
}
