using Courses.Core.Models.Users;

namespace Courses.Core.Models.Carts
{
    public class Cart
    {
        public List<CoursesCart> _coursesCart { get; protected set; }
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public User CartUser { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<CoursesCart> CoursesCart => _coursesCart;
        public Cart(User cartUser)
        {
            Id = Guid.NewGuid();
            UserId = cartUser.Id;
            CartUser = cartUser;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            _coursesCart = new List<CoursesCart>();
        }
        public void SetUserGuid(Guid userId)
        {
            if (UserId == userId)
                throw new Exception("This user has this cart");
            if (userId == Guid.Empty)
                throw new Exception("User id does not exists");
            UserId = userId;
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
