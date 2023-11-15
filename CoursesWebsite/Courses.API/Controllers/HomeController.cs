using Courses.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Courses.API.Controllers
{
    public class HomeController : ApiBaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger):base()
        {
            _logger = logger;
        }
        [Route("/")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }
        [HttpGet("Privavy")]
        public async Task<IActionResult> Privacy()
        {
            return await Task.FromResult(View());
        }
        [HttpGet("Unauthorized")]
        public new async Task<IActionResult> Unauthorized() 
        {
            return await Task.FromResult(View());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}