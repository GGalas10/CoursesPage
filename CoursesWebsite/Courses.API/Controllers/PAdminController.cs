using Courses.API.Extension;
using Courses.API.Extensions.CustomAttributes;
using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [BindUser]
    [Layout("_Menu")]
    [Route("API/PAdmin/{action}")]
    public class PAdminController : ApiBaseController
    {
        private readonly IUserService _userService;        
        public PAdminController(IUserService userService, IAdminUserService adminUserService) : base()
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (IsAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = "Logowanie";
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login command)
        {
            try
            {
                var token = await _userService.LoginAsync(command.Name, command.Password);
                if (token == null)
                {
                    throw new Exception("Wrong credentials");
                }
                AddBearerTokenToCookie(token);
                return Ok("/API/PAdmin/Index");
            }
            catch (Exception ex)
            {
                return Json("Wrong credentials");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (IsAuthenticated())
            {
                HttpContext.Response.Cookies.Delete(".ASP_Custom_Token");
                HttpContext.Response.Cookies.Delete(".ASP_Custom_RefreshToken");
                return await Task.FromResult(RedirectToAction("Login"));
            }
            return RedirectToAction("Login", "PAdmin");
        }
    }
}
