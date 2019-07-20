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


        // GET api/values/5
        [HttpGet("{UserName}")]
        public ActionResult<ShoppingList> Get(string username)
        {
            return shoppingListDac.SelectShoppingList(username);
        }

    }
}