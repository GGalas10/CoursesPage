﻿using Courses.Core.Repositories;
using Courses.Core.RepositoryDTO;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminPanelRepository _panelRepository;
        public AdminUserService(IAdminPanelRepository panelRepository)
        {
            _panelRepository = panelRepository;
        }

        public async Task<UserWithNewestCourses> GetUserDTOById(Guid UserId)
        {
            var user = await _panelRepository.GetUserForHomeViewByIdAsync(UserId);
            if (user == null)
                throw new Exception("User_Doesnt_Exist");
            return user;

        }
    }
}
