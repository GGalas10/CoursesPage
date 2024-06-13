using Courses.Core.Models.Courses;

namespace Courses.Infrastructure.DTO
{
    public class TopicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public List<LessonDTO> lessons { get; set; }
        public TopicDTO(Topic topic)
        {
            this.Id = topic.Id;
            this.Name = topic.Name;
            lessons = LessonDTO.GetFromLessonList(topic.Lessons.ToList());
        }
        public static List<TopicDTO> GetFromTopicList(List<Topic> topics)
        {
            var result = new List<TopicDTO>();
            foreach (var topic in topics)
            {
                result.Add(new TopicDTO(topic));
            }
            return result;
        }
    }
}
