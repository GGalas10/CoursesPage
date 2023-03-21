namespace Courses.Core.Models
{
    public class Cart
    {
        public Guid Id { get;protected set; }
        public Guid UserId { get;protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
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
    }
}
