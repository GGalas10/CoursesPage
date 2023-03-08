using Courses.Infrastructure.Comands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("API/PAdmin")]
    public class PAdminController : ApiBaseController
    {
        [Authorize(Policy ="RequireAdminRole")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Id"] = UserId;
            return await Task.FromResult(View());
        }
        [Authorize]
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            return await Task.FromResult(View());
        }
        [Authorize(Roles ="Admin")]
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
