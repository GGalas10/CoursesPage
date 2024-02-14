using Courses.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
namespace Courses.API.Controllers
{
    [Route("[controller]")]
    public class ApiBaseController : Controller
    {
        protected Guid UserId;
        public ApiBaseController()
        {
            UserId = User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
        }
        protected void AddBearerTokenToCookie(TokenDto token)
        {
            HttpContext.Response.Cookies.Append("Bearer", token.Token, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(15)
            });
        }
        protected bool IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
                return true;
            return false;
        }
    }
}
