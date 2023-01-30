using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        public UserController(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login comand)
        {
            _userService.LoginAsync(comand.Name, comand.Password);
            return View("Index");
        }
    }
}
