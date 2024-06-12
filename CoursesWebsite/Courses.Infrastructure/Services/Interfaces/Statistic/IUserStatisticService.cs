using Courses.Core.RepositoryDTO;

namespace Courses.Infrastructure.Services.Interfaces.Statistic
{
    public interface IUserStatisticService
    {
        Task<List<CoursesViewInAdminPanel>> GetNewestCourses(Guid UserId, int HowMuch);
    }
}
