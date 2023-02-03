using APICore.Object_Value;
using Courses.Core.Models;
using Courses.Core.Value_Object;

namespace Courses.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByLoginAsync(Name login);
        Task<User> GetByEmailAsync(Email email);
        Task RegisterAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
