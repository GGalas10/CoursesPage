using Courses.Core.Models.Courses;

namespace Courses.Core.Repositories
{
    public interface IUserStatisticRepository
    {
        Task<List<Course>> GetUserNewestCourses(Guid userId);
    }
}
