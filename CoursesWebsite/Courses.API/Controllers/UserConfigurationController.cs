using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Courses.API.Controllers
{
    public class UserConfigurationController : ApiBaseController
    {
        private readonly IUserConfigService _userConfigService;
        public UserConfigurationController(IUserConfigService userConfigService)
        {
            _userConfigService = userConfigService;
        }
        [HttpGet("GetTheme")]
        public async Task<JsonResult> GetUserTheme()
        {
            try
            {
                var config = await _userConfigService.GetUserConfigAsync(UserId);
                return Json(config.Theme);
            }catch (Exception ex)
            {
                return Json("test");
            }
        }
        public async Task<string> GetTheme()
        {
           if(User.Identity.IsAuthenticated)
            {
                var config = await _userConfigService.GetUserConfigAsync(UserId);
                return config.Theme;
            }
           return "Theme2";
        }
    }
}
