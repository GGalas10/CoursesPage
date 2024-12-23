using Courses.Core.Models.Courses;

namespace Courses.Infrastructure.DTO.CoursesDTO
{
    public class LessonEditDTO
    {
        public Guid lessonId { get; set; }
        public string lessonName { get; set; }
        public string lessonDescription { get; set; }
        public LessonEditDTO() { }
        public LessonEditDTO(Lesson lesson)
        {
            lessonId = lesson.Id;
            lessonName = lesson.LessonName;
            lessonDescription = lesson.LessonDescription;
        }
    }
}
