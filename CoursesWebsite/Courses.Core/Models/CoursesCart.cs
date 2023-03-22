namespace Courses.Core.Models
{
    public class CoursesCart
    {
        public Guid Id { get; protected set; }
        public Guid CartId { get; protected set; }
        public Guid CourseId { get; protected set; }
        private CoursesCart() { }
        public CoursesCart(Guid cartId, Guid courseId)
        {
            Id = Guid.NewGuid();
            CartId = cartId;
            CourseId = courseId;
        }
    }
}
