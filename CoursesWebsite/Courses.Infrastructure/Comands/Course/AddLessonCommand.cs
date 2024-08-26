namespace Courses.Infrastructure.Comands.Course
{
    public class AddLessonCommand
    {
        public Guid topicId { get; set; }
        public string lessonName { get; set; }
        public string lessonDescription { get; set; }
    }
}
