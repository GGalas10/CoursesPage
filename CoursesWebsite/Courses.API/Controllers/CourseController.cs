using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CourseController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
