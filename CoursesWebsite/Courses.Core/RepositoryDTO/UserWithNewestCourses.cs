using Courses.Core.Models.Users;

namespace Courses.Core.RepositoryDTO
{
    public class UserWithNewestCourses
    {
        public string UserName { get; set; }
        public List<CoursesViewInAdminPanel> newestCourses { get; set; }
        public static UserWithNewestCourses GetFromUser(User user)
        {
            return new UserWithNewestCourses()
            {
                UserName = user.UserName,
                newestCourses = CoursesViewInAdminPanel.GetFromUserList(user.CreatedUserCourses.Select(x => x.Course).ToList()),
            };
        }
    }
}
