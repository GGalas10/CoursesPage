using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var allCategory = await _categoryService.GetAllCategory();
            for (int i = 0; i <= 4; i++)
            {
                var newCategory = new CategoryDTO();
                newCategory.Id = Guid.NewGuid();
                newCategory.Name = $"CategoryName {i}";
                allCategory.Add(newCategory);
            }; 
            return Json(allCategory);
        }
        //public async Task<IActionResult> GetCategory(string id)
        //{
        //    var guidId = Guid.Parse(id);
        //}
    }
}
