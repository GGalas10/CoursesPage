﻿using Courses.Infrastructure.Comands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("API/PAdmin")]
    public class PAdminController : ApiBaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Id"] = UserId;
            return await Task.FromResult(View());
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return await Task.FromResult(View());
        }       
        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            return await Task.FromResult(View());
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login command)
        {
            return await Task.FromResult(View());
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register command)
        {

            return await Task.FromResult(View());
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Bearer");
            return await Task.FromResult(RedirectToAction("Login"));
        }
    }
}
