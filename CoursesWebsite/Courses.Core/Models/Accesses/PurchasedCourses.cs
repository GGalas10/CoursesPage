using Courses.Core.Models.Courses;
using Courses.Core.Models.Users;

namespace Courses.Core.Models.Accesses
{
    public sealed class PurchasedCourses
    {
        public Guid Id { get; set; }
        public User User { get; protected set; }
        public Course Course { get; protected set; }
        public DateTime BuyedAt { get; protected set; }
        private PurchasedCourses() { }
        public PurchasedCourses(User user, Course course)
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
            User = user;
        }
        public void SetCourse(Course course)
        {
            if (course == null)
                throw new Exception("Course cannot be null");
            Course = course;
        }
    }
}
