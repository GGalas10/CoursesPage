namespace Courses.Core.Models.Cart
{
    public class Cart
    {
        public List<CoursesCart> _Carts { get; protected set; }
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<CoursesCart> Carts => _Carts;
        public Cart(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
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
            _Carts.Add(courses);
        }
        public void RemoveFromCart(CoursesCart courses)
        {

            if (courses == null)
                throw new Exception("Courses does not be empty");
            _Carts.Remove(courses);
        }
        public void ClearCart()
        {
            _Carts.Clear();
        }
    }
}
