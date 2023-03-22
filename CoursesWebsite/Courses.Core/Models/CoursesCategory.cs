namespace Courses.Core.Models
{
    public class CoursesCategory
    {
        public Guid Id { get; protected set; }
        public Guid CourseId { get; protected set; }
        public Guid CategoryId { get; protected set; }
        private CoursesCategory() { }
        public CoursesCategory(Guid categoryId,Guid courseId)
        {
            Id = Guid.NewGuid();
            CourseId = categoryId;
            CourseId = courseId;
        }
    }
}
