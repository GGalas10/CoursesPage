using Courses.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;

namespace Courses.API.Middlewares
{
    public class RefreshTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtHandler _jwtHandler;
        public RefreshTokenMiddleware(RequestDelegate next,IJwtHandler jwtHandler)
        {
            _next = next;
            _jwtHandler = jwtHandler;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var jwtToken = context.Request.Cookies.FirstOrDefault(x=>x.Key == "Bearer").Value;
            if (jwtToken == null)
            {
                
            }
        }
    }
}
