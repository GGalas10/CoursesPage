using Courses.API.Extensions.CustomAttributes;
using Courses.Infrastructure.Services.Interfaces.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    public class UserStatisticController : ApiBaseController
    {
        private readonly IUserStatisticService _userStatisticService;
        public UserStatisticController(IUserStatisticService userStatisticService)
        {
            _userStatisticService = userStatisticService;
        }
        [BindUser]
        [HttpGet]
        public async Task<IActionResult> GetUserNewestCourses([FromQuery]int HowMuch)
        {
            try
            {
                var userCourses = await _userStatisticService.GetNewestCourses(UserId, HowMuch);
                return Json(userCourses);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
