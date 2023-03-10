namespace Courses.Core.Models
{
    public class Cart
    {
        private HashSet<Guid> _courses;
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<Guid> Courses => _courses;
        public Cart(Guid userId)
        {
            Id = new Guid();
            UserId = userId;
        }
        public void AddCourse(Guid courseId)
        {
            _courses.Add(courseId);
        }
        public void RemoveCourse(Guid courseId)
        {
            _courses.Remove(courseId);
        }
    }
}
