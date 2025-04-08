using ecomm.Domain.IServices;
using ecomm.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> addUser(UserModel user)
        {
            var result = await _userService.addUser(user);
            return Ok(result);

        }

        [HttpPost("login")]
        public async Task<IActionResult> login (UserModel user)
        {
            var result = await _userService.Login(user);
            return Ok(result);
        }

    }
}
