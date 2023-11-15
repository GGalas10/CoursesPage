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
    }
}
