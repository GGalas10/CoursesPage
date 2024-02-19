using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Courses.API.Controllers
{
    public class ApiBaseController : Controller
    {
        protected Guid UserId;
        private readonly IRoleService _roleService;
        public ApiBaseController(IRoleService roleService)
        {
            _roleService = roleService;
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
        protected async Task<string> GetUserRole()
        {
            var role = await _roleService.GetUserRoleAsync(UserId);
            return role.Name;
        }
        protected Guid GetCurrentCartId()
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            return cartId;
        }
    }
}
