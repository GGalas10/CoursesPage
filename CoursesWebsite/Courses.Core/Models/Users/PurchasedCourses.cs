namespace Courses.Core.Models.Users
{
    public class PurchasedCourses
    {
        public Guid UserId { get; protected set; }
        public Guid CourseId { get; protected set; }
        private PurchasedCourses()
        {

        }
        public PurchasedCourses(Guid userId, Guid courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }
    }
}
