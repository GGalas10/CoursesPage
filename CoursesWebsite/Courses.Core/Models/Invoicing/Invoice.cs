using Courses.Core.Models.Commons;
using Courses.Core.Models.Users;

namespace Courses.Core.Models.Invoicing
{
    public class Invoice
    {
        private List<InvoicingCourses> _Courses = new List<InvoicingCourses>();
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Guid RecipientId { get; protected set; }
        public Recipient Recipent { get; protected set; }
        public Guid BuyerId { get; protected set; }
        public Buyer Buyer { get; protected set; }
        public double TotalPrice => GetTotal();
        public IEnumerable<InvoicingCourses> Courses => _Courses;
        private Invoice() { }
        public Invoice(List<InvoicingCourses> invoicingCourses,int invoiceNumber,string? invoiceEnd,User user,Recipient recipient,Buyer buyer)
        {
            CreateId(invoiceNumber, invoiceEnd);
            SetUser(user);
            SetBuyer(buyer);
            SetRecipent(recipient);
            _Courses.AddRange(invoicingCourses);
        }
        public void AddCourseToInvoice(InvoicingCourses course)
        {
            if (course == null) throw new Exception("Courses cannot be empty");
            _Courses.Add(course);
        }
        public void AddCoursesToInvoice(List<InvoicingCourses> courses)
        {
            if (courses.Count <= 0) throw new Exception("List of courses cannot be empty");
            _Courses.AddRange(courses);
        }
        public void SetUser(User user)
        {
            if (user == null)
                throw new Exception("User cannot be empty");
            User = user;
        }
        public void SetRecipent(Recipient recipent)
        {
            if (recipent == null)
                throw new Exception("User cannot be empty");
            Recipent = recipent;
        }
        public void SetBuyer(Buyer buyer)
        {
            if (buyer == null)
                throw new Exception("User cannot be empty");
            Buyer = buyer;
        }
        public double GetTotal()
        {
            double Total = 0;
            foreach(var Course in _Courses)
            {
                Total += Course.Price;
            }
            return Total;
        }
        public void CreateId(int invoiceNumber,string? invoiceEnd)
        {
            string id = string.Empty;
            if (invoiceNumber <= 0)
                throw new Exception("Invoice number cannot be less or equal 0");
            if (string.IsNullOrEmpty(invoiceEnd))
                id = invoiceNumber + "/" + DateTime.Now.Year.ToString();
            else
                id = invoiceNumber + "/" + invoiceEnd + "/" + DateTime.Now.Year.ToString();
            Id = id;
        }
    }
}
