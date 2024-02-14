using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    //[Authorize]
    public class CourseController : ApiBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
          return View();
        }
    }
}
