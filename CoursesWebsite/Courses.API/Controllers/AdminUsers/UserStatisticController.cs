using Courses.API.Extensions.CustomAttributes;
using Courses.Infrastructure.Services.Interfaces.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    [BindUser]
    public class UserStatisticController : ApiBaseController
    {
        private readonly IUserStatisticService _userStatisticService;
        public UserStatisticController(IUserStatisticService userStatisticService)
        {
            _userStatisticService = userStatisticService;
        }
        
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
        [HttpGet]
        public async Task<IActionResult> GetUserSattlement()
        {
            try
            {
                var result = await _userStatisticService.GetUserSattlement(UserId);
                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
