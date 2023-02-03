using Courses.Core.Models;

namespace Courses.Infrastructure.Services
{
    public interface IRoleService
    {
        public Task<Role> GetUserRoleAsync(Guid id);
        public Task CreateRole(string name);
    }
}
