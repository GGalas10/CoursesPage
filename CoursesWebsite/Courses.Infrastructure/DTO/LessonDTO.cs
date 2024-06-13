using Courses.Core.Models.Courses;
using Courses.Core.Value_Object;

namespace Courses.Infrastructure.DTO
{
    public class LessonDTO
    {

        public Guid Id { get; set; }
        public Name Name { get; set; }
        public DigitalItem Video { get; set; }
        public int LessonNumber { get; set; }
        public LessonDTO(Lesson lesson) 
        {
            Id = lesson.Id;
            Name = lesson.LessonName;
            Video = lesson.Video;
            LessonNumber = lesson.LessonNumber;
        }
        public static List<LessonDTO> GetFromLessonList(List<Lesson> lessons)
        {
            var newList = new List<LessonDTO>();
            foreach (var lesson in lessons)
            {
                newList.Add(new LessonDTO(lesson));
            }
            return newList;
        }
    }
}
