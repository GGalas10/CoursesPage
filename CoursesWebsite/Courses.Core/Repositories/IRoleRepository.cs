using Courses.Core.Models;
using Courses.Core.Value_Object;

namespace Courses.Core.Repositories
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleAsync(Guid roleId);
        Task<Role> GetUserRole(Guid userId);
        Task CreateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid id);
        Task UpdateRoleAsync();
        Task AssignRole(Guid userId,Guid roleId);
    }
}
