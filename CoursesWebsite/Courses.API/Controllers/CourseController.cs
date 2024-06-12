using Courses.Infrastructure.Comands.Course;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CourseController : ApiBaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
