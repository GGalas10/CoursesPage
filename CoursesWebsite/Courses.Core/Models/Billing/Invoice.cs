using Courses.Core.Models.Common;

namespace Courses.Core.Models.Billing
{
    public class Invoice
    {
        private List<InvoicingCourses> _Courses;
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid RecipientId { get; protected set; }
        public Guid BuyerId { get; protected set; }
        public double TotalPrice => GetTotal();
        public IEnumerable<InvoicingCourses> Courses => _Courses;

        public double GetTotal()
        {
            double Total = 0;
            foreach(var Course in _Courses)
            {
                Total += Course.Price;
            }
            return Total;
        }
    }
}
