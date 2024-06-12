using Courses.Core.Models.Accesses;
using Courses.Core.Models.Courses;

namespace Courses.Core.Repositories
{
    public interface IUserStatisticRepository
    {
        Task<List<Course>> GetUserNewestCourses(Guid userId);
        Task<List<PurchasedCourses>> GetUserSattlement(Guid userId);
    }
}
