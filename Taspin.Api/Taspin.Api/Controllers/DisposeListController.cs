using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taspin.Api.Services;
using Taspin.Data.Dac;
using Taspin.Data.Models;

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
            return _disposeListService.GetUserDisposeList(username);
        }

        [HttpDelete("Item/{disposeListToItemId}")]
        public void Delete(int disposeListToItemId)
        {
            _disposeListService.DeleteItem(disposeListToItemId);
        }

        [HttpPut("Item/Move/ShoppingList/{disposeListToItemId}")]
        public void MoveToShoppingList(int disposeListToItemId)
        {
            _disposeListService.MoveToShoppingList(disposeListToItemId);
        }
    }
}
