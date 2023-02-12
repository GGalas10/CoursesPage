using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace Courses.API.Controllers
{
    [Route("[controller]")]
    public class ApiBaseController : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
    }
}
