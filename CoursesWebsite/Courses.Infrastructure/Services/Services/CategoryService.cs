using AutoMapper;
using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        

        public async Task<CategoryDTO> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> GetCategoryByNameAsync(string name)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(name);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<ViewCoursesDTO>> GetCoursesByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            var courses = await _coursesRepository.GetAllByCategoryIdAsync(id);
            return _mapper.Map<IEnumerable<ViewCoursesDTO>>(courses);
        }

        public async Task<IEnumerable<ViewCoursesDTO>> GetCoursesByNameAsync(string name)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(name);
            var courses = await _coursesRepository.GetAllByCategoryIdAsync(category.Id);
            return _mapper.Map<IEnumerable<ViewCoursesDTO>>(courses);
        }
        public async Task CreateCategory(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            var newCategory = new Category(name);
            await _categoryRepository.CreateCategoryAsync(newCategory);
            await Task.CompletedTask;
        }
        public async Task UpdateCategory(Guid id,string name)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category.Name == name)
                await Task.CompletedTask;
            category.SetName(name);
            await _categoryRepository.UpdateCategoryAsync();
        }
        public async Task DeleteCategory(Guid id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            await Task.CompletedTask;
        }       
    }
}
