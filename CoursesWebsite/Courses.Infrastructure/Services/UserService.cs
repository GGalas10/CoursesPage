using Courses.Core.Repositories;
using Courses.Infrastructure.Comands.User;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Sercurity;

namespace Courses.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly ICourseService _courseService;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordRepository _passwordRepository;
        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler,ICourseService courseService,IRoleRepository roleRepository,IPasswordRepository passwordRepository)
        {
            _roleRepository= roleRepository;
            _courseService = courseService;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _passwordRepository= passwordRepository;
        }
        public async Task BuyCoursesAsync(Guid userId, Guid courseId)
        {
            var @user = await _userRepository.GetOrFailByIdAsync(userId);
            if (@user == null)
                throw new Exception("User doesn't exist");
            var course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
                throw new Exception("Course doesn't exist");
            user.CoursesBuy(courseId);
            if(await _userRepository.UpdateAsync())
            {
                await Task.CompletedTask;
            }
            else
            {
                throw new ArgumentException("Database cannot save new data");
            }
        }
        public async Task<TokenDto> LoginAsync(string username,string password)
        {
            var @user = await _userRepository.GetOrFailByLoginAsync(username);
            if (user == null)
                throw new Exception("Wrong credentials");
            var pass = await _passwordRepository.GetByIdAsync(user.UserPassword.Id);
            if(!SecurityClass.ComparePassword(pass.NormalizedPassword,password,pass.Salt))
            {
                throw new Exception("Wrong credentials");
            }
            var role = await _roleRepository.GetUserRole(user.Id);
            var token = _jwtHandler.CreateToken(user.Id, role);
            return new TokenDto
            {
                Expires = token.Expires,
                Role = role,
                Token = token.Token,
            };
        }
        public async Task<TokenDto> RegisterAsync(string password, string email, string username,string? login)
        {
            var @user = await _userRepository.GetByLoginAsync(username);
            if (user != null)
                throw new Exception("Username already exist");
            user = await _userRepository.GetByEmailAsync(email);
            if (user != null)
                throw new Exception("Email already exist");
            user = new Courses.Core.Models.User(username,email,login);
            await _userRepository.RegisterAsync(user,password);
            var role = await _roleRepository.GetUserRole(user.Id);
            var token = _jwtHandler.CreateToken(user.Id, role);
            return new TokenDto
            {
                Expires = token.Expires,
                Role = role,
                Token = token.Token,
            };
        }
        public async Task UpdateUserAsync(Guid UserId,Register register)
        {
            var @user = await _userRepository.GetByIdAsync(UserId);
            user.SetUserName(register.UserName);
            user.SetEmail(register.UserEmail);
            var password = await _passwordRepository.GetByIdAsync(@user.Id);
            var newPassword = SecurityClass.HashPassword(register.Password, password.Salt);
            password.SetPassword(newPassword);
            await _userRepository.UpdateAsync();
            await _passwordRepository.UpdateAsync();
            await Task.CompletedTask;
        }
    }
}
