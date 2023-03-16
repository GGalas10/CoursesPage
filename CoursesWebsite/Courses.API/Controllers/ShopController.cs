﻿using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [Route("controller")]
    public class ShopController : ApiBaseController
    {
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;
        public ShopController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            return View(courses);
        }
        public async Task<IActionResult> Catergory(Guid id)
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task AddToCart(Guid courseId)
        {
            var cartId =Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            await _cartService.AddProductAsync(cartId, courseId);
        }
        [HttpPost]
        public async Task DeleteFromCart(Guid courseId)
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            await _cartService.DeleteProductAsync(cartId, courseId);
        }
    }
}
