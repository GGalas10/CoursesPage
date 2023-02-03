namespace Courses.Infrastructure.DTO
{
    public class CourseDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        public List<TopicDTO> Topics { get; set; }
    }
}
