using Newtonsoft.Json;
using System.Data;
using System.Net;

namespace Courses.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerException(context, ex);
            }
        }
        private static Task HandlerException(HttpContext context,Exception ex)
        {
            var exceptionType = ex.GetType();
            var statusCode = HttpStatusCode.InternalServerError;
            switch(ex)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException) :
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case Exception e when exceptionType == typeof(ArgumentException):
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }
            var response = new {message = ex.Message};
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsJsonAsync(payload);
        }
    }
}
