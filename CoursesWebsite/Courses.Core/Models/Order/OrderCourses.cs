namespace Courses.Core.Models.Order
{
    public class OrderCourses
    {
        public Guid Id { get; protected set; }
        public Guid OrderId { get; protected set; }
        public double Price { get; protected set; }
    }
}
