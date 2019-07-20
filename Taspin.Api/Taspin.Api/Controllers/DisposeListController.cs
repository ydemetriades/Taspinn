using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taspin.Data.Dac;
using Taspin.Data.Models;

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposeListController : ControllerBase
    {

        private readonly DisposeListDac disposeListDac;

        public DisposeListController(DisposeListDac disposeistDac)
        {
            this.disposeListDac = disposeistDac;
        }


        [HttpGet("{UserName}")]
        public ActionResult<DisposeList> Get(string username)
        {
            return disposeListDac.SelectDisposeList(username);
        }

        [HttpDelete("Item/{disposeListToItemId}")]
        public void Delete(int disposeListToItemId)
        {
            disposeListDac.DeleteItem(disposeListToItemId);
        }

        [HttpPut("Item/Move/ShoppingList/{disposeListToItemId}")]
        public void MoveToShoppingList(int disposeListToItemId)
        {
            disposeListDac.MoveItemToShoppingList(disposeListToItemId);
        }
    }
}
