using Courses.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Courses.API.Controllers
{
    [Authorize]
    public class ApiBaseController : Controller
    {
        protected Guid UserId;
        protected string UserRole;
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
        protected string GetUserRole()
        {
            if (IsAuthenticated())
            {
                var claims = HttpContext.User.Claims;
                if (claims != null)
                {
                    var userRole = claims.First(x=>x.Type == ClaimTypes.Role);
                    if (userRole == null)
                        return "User";
                    return userRole.Value;
                }
            }
            return string.Empty;
        }
        protected Guid GetUserId()
        {
            if (IsAuthenticated())
            {
                var claims = HttpContext.User.Claims;
                if (claims != null)
                {
                    var userId = claims.First(x => x.Type == ClaimTypes.Name);
                    if (userId == null)
                        return Guid.Empty;
                    return Guid.Parse(userId.Value);
                }
            }
            return Guid.Empty;
        }
        protected Guid GetCurrentCartId()
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            return cartId;
        }
        public async void InitUser()
        {
            UserRole = GetUserRole();
            UserId = GetUserId();
        }
    }
}
