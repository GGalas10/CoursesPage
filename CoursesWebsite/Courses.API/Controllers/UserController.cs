using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
