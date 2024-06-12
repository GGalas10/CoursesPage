using Courses.Infrastructure.DTO.UserDTOs;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<UserForAdminDTO> GetUserDTOById(Guid UserId);
    }
}
