using Courses.Core.Models.Category;

namespace Courses.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category> GetCategoryByNameAsync(string name);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync();
        Task DeleteCategoryAsync(Guid id);
    }
}
