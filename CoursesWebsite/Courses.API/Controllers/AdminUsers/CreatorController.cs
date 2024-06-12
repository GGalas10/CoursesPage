using Courses.API.Extension;
using Courses.API.Extensions.CustomAttributes;
using Courses.Infrastructure.DTO.UserDTOs;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    [BindUser]
    [Authorize(Roles ="Admin,Creator")]
    [Layout("_Menu")]
    public class CreatorController : ApiBaseController
    {
        private readonly IAdminUserService _adminUserService;
        public CreatorController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _adminUserService.GetUserDTOById(UserId);
                ViewData["Title"] = "Panel Twórcy";

                return View(user);
            }
            catch (Exception ex)
            {
                return View(new UserForAdminDTO() { UserName = "Undefined" });
            }
        }
        [HttpGet]
        public IActionResult Courses() 
        {
            ViewData["Title"] = "Moje kursy";
            return View();
        }
        [HttpGet]
        public IActionResult Settlements()
        {
            ViewData["Title"] = "Moje rozliczenia";
            return View();
        }
        [HttpGet]
        public IActionResult Settings()
        {
            ViewData["Title"] = "Ustawienia";
            return View();
        }
    }
}
