using Courses.Infrastructure.DTO.Statistic;
using Courses.Infrastructure.DTO.UserDTOs;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<UserForAdminDTO> GetUserDTOById(Guid UserId);
        Task<List<CoursesViewInAdminPanel>> GetAllUserCourses(Guid UserId);
        Task<UserSettingsDTO> GetUserForSettings(Guid UserId);
        Task ChangeUserName(string userName, Guid UserId);
        Task ChangeUserEmail(string email, Guid UserId);
    }
}
