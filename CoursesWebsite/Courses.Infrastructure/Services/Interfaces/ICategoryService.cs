using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategory();
        Task<CategoryDTO> GetCategoryByIdAsync(Guid id);
        Task<CategoryDTO> GetCategoryByNameAsync(string name);
        Task<IEnumerable<ViewCoursesDTO>> GetCoursesByNameAsync(string name);
        Task<IEnumerable<ViewCoursesDTO>> GetCoursesByIdAsync(Guid id);
        Task CreateCategory(string name);
        Task UpdateCategory(Guid id,string name);
        Task DeleteCategory(Guid id);
    }
}
