namespace Courses.Infrastructure.DTO
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TopicDTO> Topics { get; set; }
    }
}
