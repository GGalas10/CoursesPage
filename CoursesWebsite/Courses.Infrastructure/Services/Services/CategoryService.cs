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

        public async Task<IEnumerable<ViewCoursesDTO>> GetCoursesByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewCoursesDTO>> GetCoursesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task CreateCategory(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            var newCategory = new Category(name);
            await _categoryRepository.CreateCategoryAsync(newCategory);
            await Task.CompletedTask;
        }
        public Task UpdateCategory(string name)
        {
            throw new NotImplementedException();
        }
        public Task DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }       
    }
}
