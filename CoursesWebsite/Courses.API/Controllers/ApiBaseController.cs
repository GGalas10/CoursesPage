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
            HttpContext.Response.Cookies.Append(".ASP_Custom_Token", token.Token, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(1)
            });
            HttpContext.Response.Cookies.Append(".ASP_Custom_RefreshToken", token.RefreshToken, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(7),
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
