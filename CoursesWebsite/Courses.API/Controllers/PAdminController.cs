using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("API/PAdmin")]
    public class PAdminController : ApiBaseController
    {
        private readonly IUserService _userService;
        public PAdminController(IUserService userService) 
        {
            _userService = userService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Panel administracyjny";
            return View();
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = "Logowanie";
            return View();
        }       
        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            ViewData["Title"] = "Rejestracja";
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login command)
        {
            return await Task.FromResult(View());
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register command)
        {
            var token = await _userService.RegisterAsync(command.UserName, command.Password, command.Login, command.UserEmail, "User");
            if (token == null)
            {
                ViewData["Error"] = "Błąd rejestracji";
                return View();
            }
            HttpContext.Response.Cookies.Append("Bearer", token.Token, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(15)
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Response.Cookies.Delete("Bearer");
                return await Task.FromResult(RedirectToAction("Login"));
            }
            return RedirectToAction("Login", "PAdmin");
        }
    }
}
