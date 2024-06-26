﻿using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    [AllowAnonymous]
    public class ShopController : ApiBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;
        public ShopController(ICourseService courseService,ICategoryService categoryService,ICartService cartService):base()
        {
            _cartService = cartService;
            _categoryService = categoryService;
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var courses = await _courseService.GetAllAsync();
            ViewData["Title"] = "Sklep";
            return View();
        }
        public async Task<IActionResult> Catergory(Guid id)
        {
            var categoryCourses = await _categoryService.GetCoursesByCategoryIdAsync(id);
            return View(categoryCourses);
        }
        [HttpGet("Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            return View(course);
        }
        [HttpPost("AddToCart")]
        public async Task AddToCart(Guid courseId,double price)
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            var course = await _courseService.GetByIdAsync(courseId);
            await _cartService.AddProductAsync(courseId, course.Name,price, cartId);
        }
        [HttpPost("DeleteFromCart")]
        public async Task DeleteFromCart(Guid courseId)
        {
            var cartId = Guid.Parse(HttpContext.Request.Cookies["CartId"]);
            await _cartService.DeleteProductAsync(cartId, courseId);
        }
    }
}
