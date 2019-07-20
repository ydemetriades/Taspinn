﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taspin.Data.Dac;
using Taspin.Data.Models;

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private  readonly ShoppingListDac shoppingListDac;

        public ShoppingListController(ShoppingListDac shoppingListDac)
        {
            this.shoppingListDac = shoppingListDac;
        }

        [HttpGet("{UserName}")]
        public ActionResult<ShoppingListModel> Get(string username)
        {
            var shoppingListFromDac = shoppingListDac.SelectShoppingList(username);
            return shoppingListFromDac;
        }

        [HttpDelete("Item/{shoppingListToItemId}")]
        public ActionResult Delete(int shoppingListToItemId)
        {
            shoppingListDac.DeleteItem(shoppingListToItemId);

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