using Courses.Core.Models;

namespace Courses.Infrastructure.Services
{
    public interface IRoleService
    {
        public Task AsignRoleAsync(Guid userId, Guid roleId);
        public Task<string> GetUserRoleAsync(Guid id);
        public Task CreateRoleAsync(string name);
        public Task DeleteRoleAsync(Guid id);
        public Task UpdateRoleAsync(Role role);
    }
}
