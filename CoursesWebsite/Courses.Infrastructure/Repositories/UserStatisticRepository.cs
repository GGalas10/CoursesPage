using Courses.Core.Models.Accesses;
using Courses.Core.Models.Courses;
using Courses.Core.Repositories;
using Courses.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public sealed class UserStatisticRepository : IUserStatisticRepository
    {
        private readonly CoursesDbContext _context;
        public UserStatisticRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetUserNewestCourses(Guid userId)
        {
            var courses = await _context.Courses.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
            if (courses.Count() <= 0)
                return new List<Course>();
            return courses;
        }

        public async Task<List<PurchasedCourses>> GetUserSattlement(Guid userId)
        {
            var userCourses = await GetUserNewestCourses(userId);
            var allSellCourses = await _context.PurchasedCourses.Include(x=>x.Course).AsNoTracking().Where(x=>userCourses.Select(t=>t.Id).Contains(x.Id)).ToListAsync();
            return allSellCourses;
        }
    }
}
