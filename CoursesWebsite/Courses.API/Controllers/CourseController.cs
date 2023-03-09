using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Authorize]
    public class CourseController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }
    }
}
