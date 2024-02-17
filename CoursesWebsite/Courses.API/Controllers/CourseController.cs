using Courses.Infrastructure.Comands.Course;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    //[Authorize]
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
        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
          return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Create command)
        {
            if(command == null)
            {
                return BadRequest("Command cannot be empty");
            }
            try
            {
                await _courseService.CreateAsync(command);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
