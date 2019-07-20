using Microsoft.AspNetCore.Mvc;
using System;
using Taspin.Api.Services;
using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposeListController : ControllerBase
    {

        private readonly IDisposeListService _disposeListService;

        public DisposeListController(IDisposeListService disposeListService)
        {
            this._disposeListService = disposeListService;
        }

        [HttpGet("{UserName}")]
        public ActionResult<DisposeList> Get(string username)
        {
            try
            {
                return _disposeListService.GetUserDisposeList(username);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Item/{disposeListToItemId}")]
        public ActionResult Delete(int disposeListToItemId)
        {
            try
            {
                _disposeListService.DeleteItem(disposeListToItemId);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Item/Move/ShoppingList/{disposeListToItemId}")]
        public void MoveToShoppingList(int disposeListToItemId)
        {
            _disposeListService.MoveToShoppingList(disposeListToItemId);
        }

        [HttpPut("Item/{disposeListToItemId}/Count/{count}")]
        public void UpdateItemCount(int disposeListToItemId, int count)
        {
            _disposeListService.UpdateItemCountrer(disposeListToItemId, count);
        }
    }
}
