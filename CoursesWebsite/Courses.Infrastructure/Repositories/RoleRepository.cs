using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
using Courses.Infrastructure.Database;

namespace Courses.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CoursesDbContext _context;
        public RoleRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleAsync(Guid id)
            => await Task.FromResult(_context.Roles.FirstOrDefault(r=>r.Id==id));
        public async Task<Role> GetRoleAsync(Name name)
            => await Task.FromResult(_context.Roles.AsEnumerable().FirstOrDefault(r => r.Name.Value == name));
        public async Task AssignRole(Guid userId, Guid roleId)
        {           
            var userrole = new UserRole(userId, roleId);
            _context.UsersRoles.Add(userrole);
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }

        public async Task CreateRoleAsync(Role newRole)
        {         
            _context.Roles.Add(newRole);
            if(_context.SaveChangesAsync().Result >0)
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
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }
        public async Task UpdateRoleAsync()
        {
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }
        public async Task<Role> GetUserRole(Guid userId)
        {
            var RoleId = await Task.FromResult(_context.UsersRoles.FirstOrDefault(r=>r.UserId== userId));
            if (RoleId == null)
                throw new Exception("User doesn't have role");
            var role = await Task.FromResult(_context.Roles.FirstOrDefault(r => r.Id == RoleId.RoleId));
            if (role == null)
                throw new Exception("Role doesn't exists");
            return role;
        }       
    }
}
