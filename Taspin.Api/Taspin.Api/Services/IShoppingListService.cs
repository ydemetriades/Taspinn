using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Services
{
    public interface IShoppingListService
    {
        ShoppingList GetUserShoppingList(string username);
        void DeleteItem(int listToItemId);
        void UpdateItemCountrer(int listToItemId, int counter);
    }

    
}
