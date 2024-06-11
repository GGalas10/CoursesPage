using Courses.Core.RepositoryDTO;

namespace Courses.Core.Repositories
{
    public interface IAdminPanelRepository
    {
        Task<UserWithNewestCourses> GetUserForHomeViewByIdAsync(Guid userId);
    }
}
