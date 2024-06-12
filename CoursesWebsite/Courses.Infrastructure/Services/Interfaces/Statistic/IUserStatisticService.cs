using Courses.Infrastructure.DTO.Statistic;

namespace Courses.Infrastructure.Services.Interfaces.Statistic
{
    public interface IUserStatisticService
    {
        Task<List<CoursesViewInAdminPanel>> GetNewestCourses(Guid UserId, int HowMuch);
        Task<UserSattlementDTO> GetUserSattlement(Guid UserId);
    }
}
