using Courses.Core.Models.Category;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CoursesDbContext _context;
        public CategoryRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAll()
        => await _context.Categories.Where(cat=>cat.State == Core.Models.Common.State.Active).ToListAsync();
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        public async Task<Category> GetCategoryByNameAsync(string name)
        => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        public async Task CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
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
