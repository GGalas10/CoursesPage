namespace Courses.Infrastructure.DTO
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TopicDTO> Topics { get; set; }
    }
}
