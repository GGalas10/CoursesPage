using Courses.Infrastructure.Comands.Config;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IUserConfigService
    {
        Task CreateUserConfigAsync(Guid userId, string theme, string region);
        Task UpdateUserConfigAsync(Guid userId, UpdateConfig updateConfig);
        Task DeleteUserConfigAsync(Guid userId);
        Task<UserConfigDTO> GetUserConfigAsync(Guid userId);
    }
}
