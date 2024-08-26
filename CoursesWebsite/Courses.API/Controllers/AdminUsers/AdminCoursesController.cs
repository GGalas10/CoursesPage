using Courses.API.Extension;
using Courses.API.Extensions.CustomAttributes;
using Courses.Infrastructure.Comands.Course;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    [BindUser]
    [Layout("_Menu")]
    [Authorize(Roles = "Admin,Creator")]
    public class AdminCoursesController : ApiBaseController
    {
        private readonly ICourseService _courseService;
        public AdminCoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] Guid CourseId)
        {
            try
            {
                var result = await _courseService.GetCourseDetailsByIdAsync(CourseId);
                return View(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Create command)
        {
            try
            {
                var result = await _courseService.CreateAsync(command, UserId);
                return RedirectToAction("Details", new { CourseId = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] Guid CourseId)
        {
            try
            {
                var result = await _courseService.GetCourseDetailsByIdAsync(CourseId);
                return View(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult AddLessonView(Guid topicId)
        {
            return PartialView("~/Views/Shared/Partials/Courses/_AddLessonPartialView.cshtml", topicId);
        }
        [HttpPost]
        public async Task<IActionResult> AddTopicToCourse(AddTopic command)
        {
            try
            {
                await _courseService.AddTopicAsync(command.CourseId, command.topicName, command.topicDescription);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddLessonToTopic([FromForm]AddLessonCommand command)
        {
            try
            {
                await _courseService.AddLessonAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
