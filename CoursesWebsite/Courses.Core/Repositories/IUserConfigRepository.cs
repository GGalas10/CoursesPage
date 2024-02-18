using Courses.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Repositories
{
    public interface IUserConfigRepository
    {
        Task CreateUserConfigAsync(UserConfiguration userConfig);
        Task UpdateUserConfigAsync(int configId,UserConfiguration userConfig);
        Task DeleteUserConfigAsync(int id);
        Task<UserConfiguration> GetUserConfigAsync(Guid userId);

    }
}
