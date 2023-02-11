using Courses.Core.Models;
using Courses.Core.Value_Object;

namespace Courses.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<string> GetUserRole(Guid userId);
        Task CreateRoleAsync(Name name);
        Task DeleteRoleAsync(Guid id);
        Task UpdateRoleAsync(Role role);
        Task AssignRole(Guid userId,Guid roleId);
    }
}
