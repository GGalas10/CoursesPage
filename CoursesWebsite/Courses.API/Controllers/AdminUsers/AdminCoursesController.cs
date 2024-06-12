using Courses.API.Extension;
using Courses.API.Extensions.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    [BindUser]
    [Layout("_Menu")]
    [Authorize(Roles = "Admin,Creator")]
    public class AdminCoursesController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Details([FromQuery]Guid CourseId)
        {
            return View(CourseId);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
