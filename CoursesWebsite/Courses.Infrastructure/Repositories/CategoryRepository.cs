using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;

namespace Courses.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly CoursesDbContext _context;
        public CategoryRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        => await Task.FromResult(_context.Categories.FirstOrDefault(c => c.Id == id));
        public async Task<Category> GetCategoryByNameAsync(string name)
        => await Task.FromResult(_context.Categories.FirstOrDefault(c => c.Name == name));
        public async Task CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await UpdateCategoryAsync();
        }
        public async Task UpdateCategoryAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save data");
        }
        public async Task DeleteCategoryAsync(Guid id)
        {
            var deletedCategory = await GetCategoryByIdAsync(id);
            _context.Categories.Remove(deletedCategory);
            await UpdateCategoryAsync();
        }
    }
}
