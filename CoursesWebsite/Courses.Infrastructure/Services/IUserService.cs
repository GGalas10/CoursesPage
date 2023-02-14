using Courses.Core.Models;
using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services
{
    public interface IUserService
    {
        Task<TokenDto> LoginAsync(string username, string password);
        Task<TokenDto> RegisterAsync(string email, string password,string username,string login);
        Task BuyCoursesAsync(Guid userId, Guid courseId);
        Task UpdateUserAsync(Guid UserId, Update update);
    }
}
