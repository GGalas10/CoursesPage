namespace Courses.Infrastructure.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public List<Guid> AvailableCourses { get; set; }
    }
}