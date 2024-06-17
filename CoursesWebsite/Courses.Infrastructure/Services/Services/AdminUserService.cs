using Courses.Core.Repositories;
using Courses.Infrastructure.DTO.Statistic;
using Courses.Infrastructure.DTO.UserDTOs;
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
    }
}
