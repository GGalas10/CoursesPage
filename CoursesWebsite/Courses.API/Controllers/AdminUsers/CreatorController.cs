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
        public async Task<IActionResult> Courses() 
        {
            try
            {
                ViewData["Title"] = "Moje kursy";
                var courses = await _adminUserService.GetAllUserCourses(UserId);
                return View(courses);
            }catch(Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Settlements()
        {
            ViewData["Title"] = "Moje rozliczenia";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var result = await _adminUserService.GetUserForSettings(UserId);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeNameModal()
        {
            var result = await _adminUserService.GetUserForSettings(UserId);
            return PartialView("_ChangeNameView", result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserName([FromBody] string userName)
        {
            try
            {
                await _adminUserService.ChangeUserName(userName,UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ChangeEmailModal()
        {
            var result = await _adminUserService.GetUserForSettings(UserId);
            return PartialView("_ChangeEmailView", result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeEmailName([FromBody] string userEmail)
        {
            try
            {
                await _adminUserService.ChangeUserEmail(userEmail,UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
