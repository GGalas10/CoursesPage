using Courses.Core.Models.Courses;

namespace Courses.Infrastructure.DTO.Statistic
{
    public class CoursesViewInAdminPanel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public static List<CoursesViewInAdminPanel> GetFromUserList(List<Course> userCoureses)
        {
            var newList = new List<CoursesViewInAdminPanel>();
            if (userCoureses.Count() <= 0)
                return newList;
            foreach(Course course in userCoureses)
            {
                newList.Add(new CoursesViewInAdminPanel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Picture = "data:image/jpeg;base64, " + Convert.ToBase64String(course.Picutre),
                });
            }
            return newList;
        }
    }
}
