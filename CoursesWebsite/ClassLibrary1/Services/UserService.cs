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
            var @user = await _userRepository.GetOrFailASync(userId);
            if (@user == null)
                throw new Exception("User doesn't exist");
            var course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
                throw new Exception("Course doesn't exist");
            user.CoursesBuy(courseId);
        }

        public async Task<TokenDto> LoginAsync(string username, string password)
        {
            var @user = await _userRepository.GetByLoginAsync(username, password);
            if (user == null)
                throw new Exception("Bad credentials");
            var role = await _roleRepository.GetUserRole(user.Id);
            var token = _jwtHandler.CreateToken(user.Id, role);
            return new TokenDto
            {
                Expires = token.Expires,
                Role = role,
                Token = token.Token,
            };
        }

        public async Task<TokenDto> RegisterAsync(Guid id, string username, string password, string login)
        {
            throw new NotImplementedException();
        }
    }
}
