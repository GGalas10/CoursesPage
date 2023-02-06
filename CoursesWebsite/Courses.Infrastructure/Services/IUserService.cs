using Courses.Core.Models;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services
{
    public interface IUserService
    {
        Task<TokenDto> LoginAsync(string username, string password);
        Task<TokenDto> RegisterAsync(string username,string password,string login);
        Task BuyCourses(Guid userId, Guid courseId);
    }
}
