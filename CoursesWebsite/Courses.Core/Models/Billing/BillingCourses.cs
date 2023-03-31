namespace Courses.Core.Models.Billing
{
    public class BillingCourses
    {
        public Guid CourseId { get; protected set; }
        public Guid BillId { get; protected set; }
        public double Price { get; protected set; }
        public virtual Bill Bill { get; protected set; }
    }
}
