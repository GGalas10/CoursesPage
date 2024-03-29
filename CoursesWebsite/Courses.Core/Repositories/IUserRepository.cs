﻿using Courses.Core.Models.Users;
using Courses.Core.Value_Object;
using models = Courses.Core.Models;

namespace Courses.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByEmailAsync(string email);
        Task RegisterAsync(User user,string password);
        Task DeleteAsync(Guid id);
        Task<bool> UpdateAsync();
        Task<User> GetByRefreshToken(string refreshToken);
    }
}
