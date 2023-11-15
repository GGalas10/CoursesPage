using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Courses.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService):base()
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var allCategory = await _categoryService.GetAllCategory();
            if (allCategory.Count <= 0)
            {
                for (int i = 0; i <= 4; i++)
                {
                    var newCategory = new CategoryDTO();
                    newCategory.Id = Guid.NewGuid();
                    newCategory.Name = $"Kategoria {i}";
                    allCategory.Add(newCategory);
                };
            }
            return Json(allCategory);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory(string id)
        {
            return View(await _categoryService.GetCoursesByCategoryIdAsync(Guid.Parse(id)));
        }
    }
}
