﻿using Courses.Infrastructure.DTO;
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
        public CartController(ICartService cartService,ICourseService courseService)
        {
            _cartService = cartService;
            _courseService = courseService;
        }
        [HttpGet]
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
        [HttpGet]
        public async Task<JsonResult> GetCartProduct()
        {
            var cartId = GetCurrentCartId();
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
        [HttpPost]
        public async Task<JsonResult> AddProductToCart(Guid courseId,string courseName,double coursePrice)
        {
            try
            {
                var cartId = GetCurrentCartId();
                await _cartService.AddProductAsync(courseId, courseName, coursePrice,cartId);
                return Json("OK");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex)
                {
                    StatusCode = 403,
                };
            }
        }
        [HttpPost]
        public async Task<JsonResult> DeleteProductFromCart(Guid courseId)
        {
            try
            {
                var cartId = GetCurrentCartId();
                await _cartService.DeleteProductAsync(cartId, courseId);
                return Json("OK");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex)
                {
                    StatusCode = 403,
                };
            }
        }
    }
}
