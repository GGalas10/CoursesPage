namespace Courses.Infrastructure.Comands.Course
{
    public class AddTopic
    {
        public Guid CourseId { get; set; }
        public string topicName { get; set; }
        public string topicDescription { get; set; }
    }
}
