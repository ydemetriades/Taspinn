using Microsoft.AspNetCore.Mvc;
using Taspin.Api.Services;
using Taspin.Api.Services.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taspin.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values/5
        [HttpGet("{userName}")]
        public ActionResult<User> Get(string userName)
        {
            return _userService.Get(userName);
        }
    }
}
