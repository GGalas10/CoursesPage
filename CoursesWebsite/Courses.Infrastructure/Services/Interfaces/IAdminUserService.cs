using Courses.Core.RepositoryDTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<UserWithNewestCourses> GetUserDTOById(Guid UserId);
    }
}
