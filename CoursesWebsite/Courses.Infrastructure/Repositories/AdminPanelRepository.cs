using Courses.Core.Models.Courses;
using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class AdminPanelRepository : IAdminPanelRepository
    {
        private readonly CoursesDbContext _dbContext;
        public AdminPanelRepository(CoursesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserForHomeViewByIdAsync(Guid userId)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == userId);
            if (user == null)
                throw new Exception("User_Doesnt_Exist");
            return user;           
        }
        public async Task<List<Course>> GetAllUserCoursesAsync(Guid userId)
        {
            var courses = await _dbContext.Courses.AsNoTracking().Where(x=>x.UserId == userId).ToListAsync();
            return courses;
        }
    }
}
