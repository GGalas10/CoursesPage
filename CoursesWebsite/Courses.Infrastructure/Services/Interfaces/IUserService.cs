using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.DTO.UserDTOs.Admin;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<TokenDto> LoginAsync(string username, string password);
        Task<TokenDto> RegisterAsync(string email, string password, string username, string? login, string? role);
        Task BuyCoursesAsync(Guid userId, Guid courseId);
        Task UpdateUserAsync(Guid UserId, Update update);
        internal Task Initialize(string email, string password, string username, string login);
        Task<UserDTOForAdmin> GetUserDTOById(Guid UserId);
    }
}
