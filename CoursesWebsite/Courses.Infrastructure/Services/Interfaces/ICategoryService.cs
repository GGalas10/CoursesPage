using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryByIdAsync(Guid id);
        Task<CategoryDTO> GetCategoryByNameAsync(string name);
        Task<IEnumerable<ViewCoursesDTO>> GetCoursesByNameAsync(string name);
        Task<IEnumerable<ViewCoursesDTO>> GetCoursesByIdAsync(Guid Id);
        Task CreateCategory(string name);
        Task UpdateCategory(string name);
        Task DeleteCategory(Guid id);
    }
}
