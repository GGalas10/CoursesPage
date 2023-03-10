using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
