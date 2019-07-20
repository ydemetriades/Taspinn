using Microsoft.AspNetCore.Mvc;
using Taspin.Api.Services;
using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            this._shoppingListService = shoppingListService;
        }

        [HttpGet("{UserName}")]
        public ActionResult<ShoppingList> Get(string username)
        {
            return _shoppingListService.GetUserShoppingList(username);
        }

        [HttpDelete("Item/{shoppingListToItemId}")]
        public ActionResult Delete(int shoppingListToItemId)
        {
            _shoppingListService.DeleteItem(shoppingListToItemId);

            return Ok();
        }
        
        public class Item
        {
            public string Id { get; set; } //TODO: Int
            public string Name { get; set; }
            public string Barcode { get; set; }
            public int Count { get; set; }
        }
    }
}