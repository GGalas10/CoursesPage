using Courses.Core.Models.Users;

namespace Courses.Core.Models.Carts
{
    public class Cart
    {
        public List<CoursesCart> _coursesCart { get; protected set; }
        public Guid Id { get; protected set; }
        public Guid? UserId { get; protected set; }
        public User? CartUser { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<CoursesCart> CoursesCart => _coursesCart;
        private Cart() { }
        public Cart(User cartUser)
        {
            Id = Guid.NewGuid();
            if(cartUser != null)
                SetUser(cartUser);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            _coursesCart = new List<CoursesCart>();
        }
        public void SetUser(User user)
        {
            if (user == null)
                throw new Exception("User cannot be null");
            CartUser = user;
        }
        public void AddToCart(CoursesCart courses)
        {
            if (courses == null)
                throw new Exception("Courses does not be empty");
            _coursesCart.Add(courses);
        }
        public void RemoveFromCart(CoursesCart courses)
        {

            if (courses == null)
                throw new Exception("Courses does not be empty");
            _coursesCart.Remove(courses);
        }
        public void ClearCart()
        {
            _coursesCart.Clear();
        }
    }
}
