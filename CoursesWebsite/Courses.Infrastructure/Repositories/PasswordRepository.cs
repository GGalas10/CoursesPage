using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

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
            =>await _context.Password.FirstOrDefaultAsync(p=>p.Id == id);
        public async Task CreateAsync(UserPassword password)
        {
            await _context.Password.AddAsync(password);
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
