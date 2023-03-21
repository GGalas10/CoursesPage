namespace Courses.Core.Models
{
    public class CoursesCategory
    {
        public Guid CourseId { get; protected set; }
        public Guid CategoryId { get; protected set; }
        private CoursesCategory() { }
        public CoursesCategory(Guid categoryId,Guid courseId)
        {
            CourseId = categoryId;
            CourseId = courseId;
        }
    }
}
