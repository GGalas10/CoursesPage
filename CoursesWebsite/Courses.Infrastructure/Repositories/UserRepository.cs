﻿using Courses.Core.Models.Common;
using Courses.Core.Models.User;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
using Courses.Infrastructure.Database;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Sercurity;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CoursesDbContext _context;
        private readonly IPasswordRepository _passwordRepository;
        public UserRepository(CoursesDbContext context, IPasswordRepository passwordRepository)
        {
            _context = context;
            _passwordRepository = passwordRepository;
        }
        public async Task<User> GetByIdAsync(Guid id)
        => await Task.FromResult(_context.Users.Include(u=>u.UserPassword).FirstOrDefault(u=>u.Id==id));
        
        public async Task<User> GetByLoginAsync(string login)
        {
            var user = _context.Users.Include(u => u.UserPassword).AsEnumerable().FirstOrDefault(u=>u.Login.Value == login);
            return await Task.FromResult(user);
        }
        public async Task<User> GetByEmailAsync(Email email)
        {
            var user = _context.Users.Include(u => u.UserPassword).AsEnumerable().FirstOrDefault(u => u.Email == email);
            return await Task.FromResult(user);
        }
        public async Task RegisterAsync(User user,string password)
        {
            await Task.FromResult(_context.Users.Add(user));
            await UpdateAsync();
            var newUser = await Task.FromResult(this.GetByEmailAsync(user.Email)).Result;
            var salt = SecurityClass.CreateSalt(newUser.Id);
            var pass = SecurityClass.HashPassword(password,salt);
            var newpass = new UserPassword(pass, salt,user);
            _context.Password.Add(newpass);
            if (await UpdateAsync())
                await Task.CompletedTask;
            else
                throw new Exception($"Register can't be done.\nDatabase do not save value");
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await this.GetOrFailByIdAsync(id);
            user.SetState(State.Deleted);
            if (await UpdateAsync())
                await Task.CompletedTask;
            else
                throw new Exception("Database do not save value");
        } 
        public async Task<bool> UpdateAsync()
        {
            return (_context.SaveChanges() > 0) ? true:false;
        }
        public async Task<UserConfiguration> GetUserConfigurationAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("Userid cannot be null or empty");
            var config = await _context.UserConfigurations.FirstOrDefaultAsync(uc=>uc.UserId == userId);
            if (config == null)
                throw new Exception("Config for this user cannot exists");
            return config;
        }

    }
}
