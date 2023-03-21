namespace Courses.Core.Models
{
    public class CoursesCart
    {
        public Guid CartId { get; protected set; }
        public Guid CourseId { get; protected set; }
        private CoursesCart() { }
        public CoursesCart(Guid cartId, Guid courseId)
        {
            CartId = cartId;
            CourseId = courseId;
        }
    }
}
