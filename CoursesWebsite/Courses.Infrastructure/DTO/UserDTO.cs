namespace Courses.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> AvailableCourses { get; set; }
    }
}