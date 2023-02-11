using Courses.Core.Value_Object;

namespace Courses.Infrastructure.DTO
{
    public class LessonDTO
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public DigitalItem[] Video { get; set; }
        public int LessonNumber { get; set; }
    }
}
