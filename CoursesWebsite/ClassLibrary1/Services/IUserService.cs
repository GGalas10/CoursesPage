using APICore.Models;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(Guid id);
        Task<TokenDto> LoginAsync(string username, string password);
        Task<TokenDto> RegisterAsync(Guid id,string username,string password,string login);
        Task BuyCourses(Guid userId, Guid courseId);
    }
}
