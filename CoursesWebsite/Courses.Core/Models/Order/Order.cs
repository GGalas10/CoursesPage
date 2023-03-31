namespace Courses.Core.Models.Order
{
    public class Order
    {
        private readonly List<OrderCourses> _Courses = new List<OrderCourses>();
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get;protected set; }
        public OrderStatus Status { get; protected set; }
        public IEnumerable<OrderCourses> OrderCourses => _Courses;
    }
}
