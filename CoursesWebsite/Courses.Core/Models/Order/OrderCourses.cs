using Courses.Core.Value_Object;

namespace Courses.Core.Models.Order
{
    public class OrderCourses
    {
        public Guid Id { get; protected set; }
        public Guid OrderId { get; protected set; }
        public Name Name { get; protected set; }
        public double Price { get; protected set; }
        private OrderCourses() { }
        public OrderCourses(double price,string name)
        {
            SetName(name);
            SetPrice(price);
        }
        public void SetPrice(double price)
        {
            if (price < 0)
                throw new Exception("Price cannot be less than 0");
            Price = price;
        }
        public void SetName(Name name)
        {
            Name = name;
        }
    }
}
