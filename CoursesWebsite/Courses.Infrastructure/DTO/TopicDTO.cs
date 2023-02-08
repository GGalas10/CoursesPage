namespace Courses.Infrastructure.DTO
{
    public class TopicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
