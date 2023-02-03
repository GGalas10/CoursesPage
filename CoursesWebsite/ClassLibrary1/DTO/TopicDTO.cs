namespace Courses.Infrastructure.DTO
{
    public class TopicDTO
    {
        public string Name { get; set; }
        public int Description { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
