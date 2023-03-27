using Courses.Core.Models.User;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;

namespace Courses.Infrastructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly CoursesDbContext _context;
        public PasswordRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<UserPassword> GetByIdAsync(Guid id)
            =>await Task.FromResult(_context.Password.FirstOrDefault(p=>p.Id == id));
        public async Task CreateAsync(UserPassword password)
        {
            await Task.FromResult(_context.Password.Add(password));
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save date");
        }
        public async Task UpdateAsync()
        {
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save date");
        }
    }
}
