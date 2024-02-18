using Courses.Core.Models.Commons;
using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
using Courses.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

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
            => await _context.Roles.FirstOrDefaultAsync(r=>r.Id==id);
        public async Task<Role> GetRoleAsync(Name name)
            => await _context.Roles.FirstOrDefaultAsync(r => r.Name.Value == name);
        public async Task AssignRole(Guid userId, Guid roleId)
        {           
            var userrole = new UserRole(userId, roleId);
            await _context.UsersRoles.AddAsync(userrole);
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }

        public async Task CreateRoleAsync(Role newRole)
        {         
            await _context.Roles.AddAsync(newRole);
            if(_context.SaveChangesAsync().Result >0)
                await Task.CompletedTask;
            else
                throw new Exception("Database can't save date");
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var newrole = await _context.Roles.FirstOrDefaultAsync(role=> role.Id == id);
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
            var RoleId = await _context.UsersRoles.FirstOrDefaultAsync(r => r.UserId == userId);
            if (RoleId == null)
                throw new Exception("User doesn't have role");
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == RoleId.RoleId);
            if (role == null)
                throw new Exception("Role doesn't exists");
            return role;
        }       
    }
}
