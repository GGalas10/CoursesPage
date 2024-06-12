using Courses.Core.Models.Users;

namespace Courses.Core.Repositories
{
    public interface IAdminPanelRepository
    {
        Task<User> GetUserForHomeViewByIdAsync(Guid userId);
    }
}
