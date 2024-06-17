using Courses.Core.Models.Courses;
using Courses.Core.Models.Users;

namespace Courses.Core.Repositories
{
    public interface IAdminPanelRepository
    {
        Task<User> GetUserForHomeViewByIdAsync(Guid userId);
        Task<List<Course>> GetAllUserCoursesAsync(Guid userId);
    }
}
