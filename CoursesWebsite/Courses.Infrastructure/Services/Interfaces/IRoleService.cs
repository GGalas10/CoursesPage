using Courses.Core.Models;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IRoleService
    {
        public Task AsignRoleAsync(Guid userId, Guid roleId);
        public Task<Guid> GetRoleIdByNameAsync(string name);
        public Task<Role> GetRoleIdByIdAsync(Guid id);
        public Task<Role> GetUserRoleAsync(Guid userId);
        public Task CreateRoleAsync(string name);
        public Task DeleteRoleAsync(Guid id);
        public Task UpdateRoleAsync(Role role);
    }
}
