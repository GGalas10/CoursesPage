using Courses.Infrastructure.Comands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("API/PAdmin")]
    public class PAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login command)
        {
            return View();
        }
        public async Task<IActionResult> Register(Register command)
        {

            return View();
        }
    }
}
