using APICore.Object_Value;
using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Infrastructure;

namespace Courses.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CoursesDbContext _context;
        public RoleRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task AssignRole(Guid userId, Guid roleId)
        {
            if (userId == Guid.Empty || roleId == Guid.Empty)
                throw new Exception("Guids cannot be empty");
            var user = await Task.FromResult(_context.UsersRoles.FirstOrDefault(u=>u.UserId == userId));
            if (user != null)
                throw new Exception("User already has a role.");
            var userrole = new UserRole(userId, roleId);
            _context.UsersRoles.Add(userrole);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }

        public async Task CreateRoleAsync(Name name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new Exception("Role cannot be empty");
            var CheckName = await Task.FromResult(_context.Roles.FirstOrDefault(u => u.Name == name));
            if (CheckName != null)
                throw new Exception($"{name} already exists");
            var newrole = new Role(name);
            _context.Roles.Add(newrole);
            if(await _context.SaveChangesAsync()>0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var newrole = await Task.FromResult(_context.Roles.FirstOrDefault(role=> role.Id == id));
            if (newrole == null)
                throw new Exception("Role doesn't exists");
            newrole.SetState(State.Deleted);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }
        public async Task UpdateRoleAsync(Role role)
        {
            var oldrole = await Task.FromResult(_context.Roles.FirstOrDefault(r=>r.Id == role.Id));
            if (oldrole == null) 
                throw new Exception("Role doesn't exists");
            oldrole.SetName(role.Name);
            oldrole.SetState(role.State);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }
        public async Task<string> GetUserRole(Guid userId)
        {
            var RoleId = await Task.FromResult(_context.UsersRoles.FirstOrDefault(r=>r.UserId== userId));
            if (RoleId == null)
                throw new Exception("User doesn't have role");
            var RoleName = await Task.FromResult(_context.Roles.FirstOrDefault(r => r.Id == RoleId.RoleId));
            if (string.IsNullOrWhiteSpace(RoleName.Name))
                throw new Exception("Role doesn't exists");
            return RoleName.Name;
        }       
    }
}
