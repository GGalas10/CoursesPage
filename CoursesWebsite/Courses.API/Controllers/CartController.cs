using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Courses.API.Controllers
{
    public class CartController : ApiBaseController
    {      
        private readonly ICartService _cartService;
        private readonly ICourseService _courseService;
        public CartController(ICartService cartService,ICourseService courseService):base()
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
        [HttpGet("GetCartProduct")]
        public async Task<JsonResult> GetCartProduct()
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            var cart = await _cartService.GetCartById(cartId);
            if (cart.ProductGuid.Count() <= 0)
            {
                for(int i = 0;i < 10;i++)
                {
                    cart.ProductGuid.Add(Guid.NewGuid());
                }
            }
            return Json(cart.ProductGuid);
        }
    }
}
