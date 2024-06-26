﻿using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Sercurity;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly ICourseService _courseService;
        private readonly IRoleService _roleService;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IUserConfigService _userConfigService;
        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler, ICourseService courseService, IRoleService roleService, IPasswordRepository passwordRepository, IUserConfigService userConfigService)
        {
            _roleService = roleService;
            _courseService = courseService;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _passwordRepository = passwordRepository;
            _userConfigService = userConfigService;
        }
        public async Task<TokenDto> LoginAsync(string username, string password)
        {
            try
            {
                var @user = await _userRepository.GetOrFailByLoginAsync(username);
                if (user == null)
                    throw new Exception("Wrong credentials");
                var pass = await _passwordRepository.GetByIdAsync(user.UserPassword.Id);
                if (!SecurityClass.ComparePassword(pass.NormalizedPassword, password, pass.Salt))
                {
                    throw new Exception("Wrong credentials");
                }
                var role = await _roleService.GetUserRoleAsync(user.Id);
                var token = await _jwtHandler.LoginUserAsync(user.Id);
                return new TokenDto
                {
                    Expires = token.tokenJWT.Expires,
                    RefreshToken = token.refreshToken,
                    Role = role.Name,
                    Token = token.tokenJWT.Token,
                };
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TokenDto> RegisterAsync(string email, string password, string username, string? login, string? role)
        {
            if (string.IsNullOrEmpty(username))
                username = login;
            var @user = await _userRepository.GetByLoginAsync(username);
            if (user != null)
                throw new Exception("Username already exist");
            user = await _userRepository.GetByEmailAsync(email);
            if (user != null)
                throw new Exception("Email already exist");
            user = new User(username, email, login);
            await _userRepository.RegisterAsync(user, password);
            var usRole = await _roleService.GetRoleIdByNameAsync(role);
            if (usRole == Guid.Empty || usRole == null)
                throw new Exception("role does not exist");
            await _roleService.AsignRoleAsync(user.Id, usRole);
            await _userRepository.UpdateAsync();
            await _userConfigService.CreateUserConfigAsync(user.Id, "Theme1", "Pl-pl");
            var token = await LoginAsync(username, password);
            return token;
        }
        public async Task BuyCoursesAsync(Guid userId, Guid courseId)
        {
            var @user = await _userRepository.GetOrFailByIdAsync(userId);
            if (@user == null)
                throw new Exception("User doesn't exist");
            var course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
                throw new Exception("Course doesn't exist");
            if (await _userRepository.UpdateAsync())
            {
                await Task.CompletedTask;
            }
            else
            {
                throw new ArgumentException("Database cannot save new data");
            }
        }
        public async Task UpdateUserAsync(Guid UserId, Update update)
        {
            var @user = await _userRepository.GetByIdAsync(UserId);
            user.SetUserName(update.Login);
            user.SetEmail(update.Email);
            var password = await _passwordRepository.GetByIdAsync(@user.Id);
            var newPassword = SecurityClass.HashPassword(update.Password, password.Salt);
            password.SetPassword(newPassword);
            await _userRepository.UpdateAsync();
            await _passwordRepository.UpdateAsync();
            await Task.CompletedTask;
        }
        async Task IUserService.Initialize(string email, string password, string username, string login)
        {
            var user = new User(username, email, login);
            await _userRepository.RegisterAsync(user, password);
            await _userConfigService.CreateUserConfigAsync(user.Id, "Theme1", "PL-pl");
            await Task.CompletedTask;
        }        
    }
}
