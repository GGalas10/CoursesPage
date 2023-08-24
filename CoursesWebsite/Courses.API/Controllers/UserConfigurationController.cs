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
        [HttpGet("GetUserTheme")]
        public async Task<JsonResult> GetUserTheme()
        {
            if (!User.Identity.IsAuthenticated)
                return Json("Theme2");
            var config = await _userConfigService.GetUserConfigAsync(Guid.Parse(User.Identity.Name));
            return Json(config.Theme);

        }
        [HttpGet("ChangeTheme")]
        public async Task<JsonResult> ChangeTheme()
        {
            var config = await _userConfigService.GetUserConfigAsync(Guid.Parse(User.Identity.Name));
            if (config.Theme == "Theme1")
                await _userConfigService.UpdateUserConfigAsync(Guid.Parse(User.Identity.Name), new Infrastructure.Comands.Config.UpdateConfig() { Theme = "Theme2" });
            else
                await _userConfigService.UpdateUserConfigAsync(Guid.Parse(User.Identity.Name), new Infrastructure.Comands.Config.UpdateConfig() { Theme = "Theme1" });
            return Json(config.Theme);
        }
    }
}
