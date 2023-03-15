using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("controller")]
    public class ShopController : ApiBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
