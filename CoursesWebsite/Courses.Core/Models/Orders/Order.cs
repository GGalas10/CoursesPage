using Courses.Core.Models.Carts;
using Courses.Core.Models.Courses;

namespace Courses.Core.Models.Orders
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
        private Order() { }
        public Order(Guid userId,List<OrderCourses> courses)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            AddCourses(courses);
            Status = OrderStatus.Created;
        }
        public Order(Cart cart)
        {
            Id = Guid.NewGuid();
            UserId = (Guid)cart.UserId;
            foreach(var oneCourse in cart.CoursesCart)
            {
                AddCourse(new OrderCourses(oneCourse.Price, oneCourse.Name));
            }
            Status = OrderStatus.Created;
        }
        public void AddCourse(OrderCourses course)
        {
            if (course == null)
                throw new Exception("Course cannot be empty");
            _Courses.Add(course);
            UpdatedAt = DateTime.Now;
        }
        public void AddCourses(List<OrderCourses> courses)
        {
            if (courses.Count <= 0)
                throw new Exception("Courses list cannot be empty");
            _Courses.AddRange(courses);
            UpdatedAt = DateTime.Now;
        }
        public void UpdateCoursePrice(Guid courseId, double price)
        {
            var course = _Courses.FirstOrDefault(c=>c.Id == courseId);
            if (course == null)
                throw new Exception($"Cannot find course with this ID {courseId}");
            course.SetPrice(price);
        }
        public void RemoveCourse(Guid courseId)
        {
            var course = _Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new Exception($"Cannot find course with this ID {courseId}");
            _Courses.Remove(course);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }
    }
}
