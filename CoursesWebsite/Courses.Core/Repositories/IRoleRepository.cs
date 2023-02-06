using APICore.Object_Value;
using Courses.Core.Models;

namespace Courses.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<string> GetUserRole(Guid userId);
        Task CreateRoleAsync(Name name);
        Task DeleteRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task AssignRole(Guid userId,Guid roleId);
    }
}
