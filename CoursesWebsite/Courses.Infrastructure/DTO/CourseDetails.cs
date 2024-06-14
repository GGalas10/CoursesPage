using Courses.Core.Models.Courses;

namespace Courses.Infrastructure.DTO
{
    public class CourseDetails
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public double Price { get;set; }
        public string Picture { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public CourseDetails(Course course)
        {
            Id = course.Id;
            Title = course.Name;
            Author = course.Author;
            Description = course.Description;
            CreatedAt = course.CreatedAt;
            Price = course.Price;
            Picture = "data:image/jpeg;base64, " + Convert.ToBase64String(course.Picutre);
            Topics = TopicDTO.GetFromTopicList(course.Topics != null ? course.Topics.ToList() : new List<Topic>());
        }
    }
}
