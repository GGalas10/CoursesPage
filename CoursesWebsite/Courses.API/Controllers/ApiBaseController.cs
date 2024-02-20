using Courses.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Courses.API.Controllers
{
    public class ApiBaseController : Controller
    {
        protected Guid UserId;
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
        protected async Task<string> GetUserRole()
        {
            if (IsAuthenticated())
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userRole =  identity.FindFirst("Role").Value;
                    return userRole;
                }
            }
            return string.Empty;
        }
        protected Guid GetCurrentCartId()
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            return cartId;
        }
    }
}
