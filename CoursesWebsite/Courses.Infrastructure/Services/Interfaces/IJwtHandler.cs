﻿using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IJwtHandler
    {
        JWTDTO CreateToken(Guid userId, string role);
        Task<LoginModel> LoginUserAsync(Guid userId);

        Task<LoginModel> LoginWithRefreshToken(string refreshToken);
    }
}
