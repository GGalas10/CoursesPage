using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Courses.API.Controllers
{
    [Route("controller")]
    public class CartController : ApiBaseController
    {      
        private readonly ICartService _cartService;
        private readonly ICourseService _courseService;
        public CartController(ICartService cartService,ICourseService courseService)
        {
            _cartService = cartService;
            _courseService = courseService;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            if (User.Identity.IsAuthenticated)
            {
                var userCart = await _cartService.GetCartById(cartId);
                if (userCart == null)
                {
                    IEnumerable<CartCourseDTO> cart = new List<CartCourseDTO>();
                    return View(cart);
                }
                var Courses = await _courseService.GetCoursesForCart(userCart.ProductGuid);
                return View(Courses);
            }
            else
            {
                var baseCart = await _cartService.GetCartById(cartId);
                if (baseCart == null)
                {
                    IEnumerable<CartCourseDTO> cart = new List<CartCourseDTO>();
                    return View(cart);
                }
                var Courses = await _courseService.GetCoursesForCart(baseCart.ProductGuid);
                return View(Courses);
            }
        }
    }
}
