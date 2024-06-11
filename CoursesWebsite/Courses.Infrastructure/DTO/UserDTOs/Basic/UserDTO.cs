namespace Courses.Infrastructure.DTO.UserDTOs.Basic
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> AvailableCourses { get; set; }
    }
}