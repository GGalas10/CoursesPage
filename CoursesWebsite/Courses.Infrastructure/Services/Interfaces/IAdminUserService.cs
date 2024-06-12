using Courses.Core.RepositoryDTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<UserForAdminDTO> GetUserDTOById(Guid UserId);
    }
}
