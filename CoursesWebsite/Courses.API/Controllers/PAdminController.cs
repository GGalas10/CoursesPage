using Courses.API.Extension;
using Courses.API.Extensions.CustomAttributes;
using Courses.Core.RepositoryDTO;
using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [BindUser]
    [Layout("_Menu")]
    [Route("API/PAdmin")]
    public class PAdminController : ApiBaseController
    {
        private readonly IUserService _userService;
        private readonly IAdminUserService _adminUserService;
        public PAdminController(IUserService userService, IAdminUserService adminUserService) : base()
        {
            _userService = userService;
            _adminUserService = adminUserService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _adminUserService.GetUserDTOById(UserId);
                ViewData["Title"] = "Panel administracyjny";

                return View(user);
            }catch(Exception ex) 
            {
                return View(new UserWithNewestCourses() { UserName = "Undefined" });
            }
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (IsAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = "Logowanie";
            return View();
        }
        [HttpPost("Login")]
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
                return RedirectToAction("Index");
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
                HttpContext.Response.Cookies.Delete("Bearer");
                return await Task.FromResult(RedirectToAction("Login"));
            }
            return RedirectToAction("Login", "PAdmin");
        }
    }
}
