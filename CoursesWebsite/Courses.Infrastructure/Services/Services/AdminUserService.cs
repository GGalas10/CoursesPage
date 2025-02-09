using Courses.Core.Repositories;
using Courses.Infrastructure.DTO.Statistic;
using Courses.Infrastructure.DTO.UserDTOs;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminPanelRepository _panelRepository;
        private readonly IUserRepository _userRepository;
        public AdminUserService(IAdminPanelRepository panelRepository,IUserRepository userRepository)
        {
            _panelRepository = panelRepository;
            _userRepository = userRepository;
        }
        public async Task<UserForAdminDTO> GetUserDTOById(Guid UserId)
        {
            var user = await _panelRepository.GetUserForHomeViewByIdAsync(UserId);
            if (user == null)
                throw new Exception("User_Doesnt_Exist");
            return new UserForAdminDTO(user);
        }
        public async Task<List<CoursesViewInAdminPanel>> GetAllUserCourses(Guid UserId)
        {
            var courses = await _panelRepository.GetAllUserCoursesAsync(UserId);
            return CoursesViewInAdminPanel.GetFromUserList(courses);
        }
        public async Task<UserSettingsDTO> GetUserForSettings(Guid UserId)
        {
            var result = await _userRepository.GetByIdAsync(UserId);
            return UserSettingsDTO.GetFromModel(result);
        }
        public async Task ChangeUserName(string userName, Guid UserId)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("New_User_Name_Cannot_Be_Null_Or_Empty");

            await _userRepository.ChangeUserName(userName,UserId);
        }
        public async Task ChangeUserEmail(string email, Guid UserId)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("New_User_Name_Cannot_Be_Null_Or_Empty");

            await _userRepository.ChangeUesrEmail(email,UserId);
        }
    }
}
