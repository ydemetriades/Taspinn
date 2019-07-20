using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Services
{
    public interface IDisposeListService
    {
        DisposeList GetUserDisposeList(string username);
        void DeleteItem(int listToItemId);
        void MoveToShoppingList(int listToItemId);
        void UpdateItemCountrer(int listToItemId, int counter);
    }

    
}
