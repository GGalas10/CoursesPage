﻿using Courses.Infrastructure.DTO.Statistic;
using Courses.Infrastructure.DTO.UserDTOs;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<UserForAdminDTO> GetUserDTOById(Guid UserId);
        Task<List<CoursesViewInAdminPanel>> GetAllUserCourses(Guid UserId);
    }
}
