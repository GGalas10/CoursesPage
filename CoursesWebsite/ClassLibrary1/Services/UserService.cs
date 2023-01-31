using APICore.Repositories;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Settings;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly ICourseService _courseService;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler,ICourseService courseService,IRoleRepository roleRepository)
        {
            _roleRepository= roleRepository;
            _courseService = courseService;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }
        public async Task BuyCourses(Guid userId, Guid courseId)
        {
            var @user = await _userRepository.GetOrFailByIdAsync(userId);
            if (@user == null)
                throw new Exception("User doesn't exist");
            var course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
                throw new Exception("Course doesn't exist");
            user.CoursesBuy(courseId);
            await _userRepository.UpdateAsync(user);
        }
        public async Task<TokenDto> LoginAsync(string username,string password)
        {
            var @user = await _userRepository.GetOrFailByLoginAsync(username);
            if (user == null)
                throw new Exception("Wrong credentials");
            if (user.Password != password)
                throw new Exception("Wrong credentials");
            var role = await _roleRepository.GetUserRole(user.Id);
            var token = _jwtHandler.CreateToken(user.Id, role);
            return new TokenDto
            {
                Expires = token.Expires,
                Role = role,
                Token = token.Token,
            };
        }
        public async Task<TokenDto> RegisterAsync(string username, string password, string email)
        {
            var @user = await _userRepository.GetByLoginAsync(username);
            if (user != null)
                throw new Exception("Username already exist");
            user = await _userRepository.GetByEmailAsync(email);
            if (user != null)
                throw new Exception("Email already exist");
            user = new APICore.Models.User(username,email,password);
            await _userRepository.RegisterAsync(user);
            var role = await _roleRepository.GetUserRole(user.Id);
            var token = _jwtHandler.CreateToken(user.Id, role);
            return new TokenDto
            {
                Expires = token.Expires,
                Role = role,
                Token = token.Token,
            };
        }
    }
}
