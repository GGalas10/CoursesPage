using Courses.Core.Models.Common;
using Courses.Core.Models.User;
using Courses.Core.Repositories;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task AsignRoleAsync(Guid userId, Guid roleId)
        {
            var user = _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User doesn't exists");
            var role = _roleRepository.GetRoleAsync(roleId);
            if (role == null)
                throw new Exception("Role doesn't exists");
            await _roleRepository.AssignRole(userId, roleId);
        }
        public async Task<Guid> GetRoleIdByNameAsync(string name)
            => await Task.FromResult(_roleRepository.GetRoleAsync(name).Result.Id);
        public async Task<Role> GetRoleIdByIdAsync(Guid id)
            => await _roleRepository.GetRoleAsync(id);
        public async Task<Role> GetUserRoleAsync(Guid userId)
        => await _roleRepository.GetUserRole(userId);
        public async Task CreateRoleAsync(string name)
        {
            var newRole = new Role(name);
            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _roleRepository.GetRoleAsync(id);
            if (role == null && role.State == State.Deleted)
                throw new Exception("Role doesn't exists");
            await _roleRepository.DeleteRoleAsync(id);
        }
        public async Task UpdateRoleAsync(Role role)
        {
            var updateRole = await _roleRepository.GetRoleAsync(role.Id);
            updateRole.SetName(role.Name);
            await _roleRepository.UpdateRoleAsync();
        }
    }
}
