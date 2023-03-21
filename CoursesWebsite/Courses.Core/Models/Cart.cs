namespace Courses.Core.Models
{
    public class Cart
    {
        private HashSet<Guid> _courses;
        public Guid Id { get;protected set; }
        public Guid UserId { get;protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Guid> Courses => _courses;
        public Cart(Guid userId)
        {
            _courses = new HashSet<Guid>();
            Id = Guid.NewGuid();
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public void AddCourse(Guid courseId)
        {
            UpdatedAt = DateTime.UtcNow;
            _courses.Add(courseId);
        }
        public void RemoveCourse(Guid courseId)
        {
            UpdatedAt = DateTime.UtcNow;
            _courses.Remove(courseId);
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
