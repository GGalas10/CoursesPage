using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        public UserController(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Lista kursów użytkownika";
            return View();
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            ViewData["Title"] = "Logowanie";
            return View();
        }
        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            ViewData["Title"] = "Rejestracja";
            return View();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register command)
        {
            var token = await _userService.RegisterAsync(command.UserName, command.Password, command.Login, command.UserEmail);
            if (token == null)
            {
                ViewData["Error"] = "Błąd rejestracji";
                return View();
            }
            HttpContext.Response.Cookies.Append("Bearer", token.Token);
            return RedirectToAction("Index");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login comand)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.LoginAsync(comand.Name, comand.Password);
                if(token == null)
                    ViewData["Error"] = "Błędne dane logowania";
                HttpContext.Response.Cookies.Append("Bearer", token.Token,new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddMinutes(15)
                });
                return await Task.FromResult(View("Index"));
            }
            else
            {
                ViewData["Error"] = "Podano błędne wartości";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Bearer");
            return await Task.FromResult(RedirectToAction("Login"));
        }
    }
}
