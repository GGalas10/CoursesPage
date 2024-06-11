using Courses.API.Extension;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers.AdminUsers
{
    [Layout("_Menu")]
    public class CreatorController : ApiBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Courses() 
        { 
            return View();
        }
        [HttpGet]
        public IActionResult Settlements()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
    }
}
