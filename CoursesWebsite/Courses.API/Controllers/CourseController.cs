using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
