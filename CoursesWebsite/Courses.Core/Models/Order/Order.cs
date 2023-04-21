﻿namespace Courses.Core.Models.Order
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
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }
    }
}
