using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taspin.Data.Dac;
using Taspin.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UsersDac _dac;

        public UserController(UsersDac dac)
        {
            _dac = dac;
        }

        // GET api/values/5
        [HttpGet("{userName}")]
        public ActionResult<UserModel> Get(string userName)
        {
            return _dac.SelectUser(userName);
        }
    }
}
