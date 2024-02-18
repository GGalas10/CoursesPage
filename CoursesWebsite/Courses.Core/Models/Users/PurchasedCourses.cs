using Courses.Core.Models.Courses;

namespace Courses.Core.Models.Users
{
    public class UserCoursesAccess
    {
        public Guid Id { get; set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Guid CourseId { get; protected set; }
        public Course Course { get; protected set; }
        public DateTime BuyedAt { get; protected set; }
        private UserCoursesAccess(){}
        public UserCoursesAccess(User user, Course course)
        {
            Id = Guid.NewGuid();
            SetUser(user);
            SetCourse(course);
            BuyedAt = DateTime.UtcNow;
        }
        public void SetUser(User user)
        {
            if (user == null)
                throw new Exception("User cannot be null");
        }
        public void SetCourse(Course course)
        {
            if (course == null)
                throw new Exception("Course cannot be null");
        }
    }
}
