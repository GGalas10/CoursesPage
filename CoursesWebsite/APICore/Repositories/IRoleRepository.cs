using APICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Repositories
{
    public interface IRoleRepository
    {
        Task<string> GetUserRole(Guid userId);
        Task CreateRoleAsync(string name);
        Task DeleteRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task AssignRole(Guid userId,Guid roleId);
    }
}
