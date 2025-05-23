﻿using ecomm.Domain.Dtos.User;
using ecomm.Domain.IServices;
using ecomm.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> addUser(UserAddDto user)
        {
            var result = await _userService.addUser(user);
            return Ok(result);

        }

        [HttpPost("login")]
        public async Task<IActionResult> login (UserLoginDto user)
        {
            var result = await _userService.Login(user);
            return Ok(result);
        }

    }
}
