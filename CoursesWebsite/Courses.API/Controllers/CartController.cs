using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CartController : ApiBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
