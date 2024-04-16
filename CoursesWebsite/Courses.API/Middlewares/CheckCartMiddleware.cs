using Courses.Core.Models;
using Courses.Infrastructure.Services.Interfaces;
using Courses.Infrastructure.Services.Services;

namespace Courses.API.Middlewares
{
    public class CheckCartMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICartService _cartService;
        public CheckCartMiddleware(RequestDelegate next,ICartService cartService)
        {
            _next = next;
            _cartService = cartService;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            if(context.Request.Cookies.ContainsKey("CartId"))
            {
                    await _next(context);
            }
            else
            {
                if (context.Request.Cookies.ContainsKey(".ASP_Custom_Token"))
                {
                    var newCart = await _cartService.CreateCartAsync(Guid.Parse(context.User.Identity.Name));
                    context.Response.Cookies.Append("CartId", newCart.ToString(), new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Secure = true,
                        Expires = DateTime.UtcNow.AddDays(7)
                    });
                }
                else
                {
                    var newCart = await _cartService.CreateCartAsync(Guid.Empty);
                    context.Response.Cookies.Append("CartId", newCart.ToString(), new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Secure = true,
                        Expires = DateTime.UtcNow.AddDays(7)
                    });
                }
                await _next(context);

            }   
        }
    }
}
