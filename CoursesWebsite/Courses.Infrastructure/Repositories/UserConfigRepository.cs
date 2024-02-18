using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class UserConfigRepository : IUserConfigRepository
    {
        private readonly CoursesDbContext _context;
        public UserConfigRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task CreateUserConfigAsync(UserConfiguration userConfig)
        {
            if (userConfig == null)
                throw new Exception("User configuration cannot be null or empty");
            await _context.UserConfigurations.AddAsync(userConfig);
            if (await _context.SaveChangesAsync() < 0)
                throw new Exception("Database cannot add user configuration");
            await Task.CompletedTask;
        }
        public async Task UpdateUserConfigAsync(int configId,UserConfiguration userConfig)
        {
            if (userConfig == null)
                throw new Exception("User configuration cannot be null or empty");
            var updatedConfig = await _context.UserConfigurations.FirstOrDefaultAsync(u=>u.Id == configId);
            updatedConfig.UpdateUserConfiguration(userConfig.Region, userConfig.Theme);
            if (await _context.SaveChangesAsync() < 0)
                throw new Exception("Database cannot update user configuration");
            await Task.CompletedTask;
        }

        public Task DeleteUserConfigAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserConfiguration> GetUserConfigAsync(Guid userId)
        {
            var config = await _context.UserConfigurations.FirstOrDefaultAsync(c=>c.UserId == userId);
            if (config == null)
                throw new Exception("Config for this user doesnt exists");
            return config;
        }        
    }
}
