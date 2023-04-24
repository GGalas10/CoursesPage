using Courses.Core.Value_Object;

namespace Courses.Core.Models.Invoicing
{
    public class InvoicingCourses
    {
        public Guid CourseId { get; protected set; }
        public Guid BillId { get; protected set; }
        public Name CourseName { get; protected set; }
        public double Price { get; protected set; }
        public virtual Invoice Invoice { get; protected set; }
        private InvoicingCourses() { }
        public InvoicingCourses(Guid courseId,string courseName,double price)
        {
            CourseId = courseId;
            SetCourseName(courseName);
            SetPrice(price);
        }
        public void SetCourseName(Name courseName)
        {
            if (string.IsNullOrEmpty(courseName))
                throw new Exception("Name cannot be empty");
            CourseName = courseName;
        }
        public void SetPrice(double price)
        {
            if (price < 0) throw new Exception("Price cannot be less than 0");
            Price = Math.Round(price,2);
        }
    }
}
