using AutoMapper;
using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.Infrastructure.Comands.Config;
using Courses.Infrastructure.DTO.UserDTOs.Basic;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class UserConfigService : IUserConfigService
    {
        private readonly IUserConfigRepository _userConfigRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserConfigService(IUserConfigRepository userConfigRepository, IUserRepository userRepository,IMapper mapper)
        {
            _userConfigRepository = userConfigRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateUserConfigAsync(Guid userId, string theme, string region)
        {
            var user = await _userRepository.GetOrFailByIdAsync(userId);
            var newConfig = new UserConfiguration(user, theme, region);
            await _userConfigRepository.CreateUserConfigAsync(newConfig);         
        }
        public async Task UpdateUserConfigAsync(Guid userId, UpdateConfig updateConfig)
        {
            var config = await _userConfigRepository.GetUserConfigAsync(userId);
            config.UpdateUserConfiguration(updateConfig.Region, updateConfig.Theme);
            await _userConfigRepository.UpdateUserConfigAsync(config.Id,config);
        }
        public async Task DeleteUserConfigAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User id cannot be null or empty");
            var config = await _userConfigRepository.GetUserConfigAsync(userId);
            await _userConfigRepository.DeleteUserConfigAsync(config.Id);
        }

        public async Task<UserConfigDTO> GetUserConfigAsync(Guid userId)
        {
            if(userId == Guid.Empty)
                throw new Exception("User id cannot be null or empty");
            return _mapper.Map<UserConfigDTO>(await _userConfigRepository.GetUserConfigAsync(userId));
        }
    }
}
