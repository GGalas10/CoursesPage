using Courses.Core.Models.Common;

namespace Courses.Core.Models.Invoicing
{
    public class Recipient
    {
        private readonly List<Invoice> _Invoices;
        public Guid Id { get; protected set; }
        public Address DeliveryAdress { get;protected set; }
        public IEnumerable<Invoice> Invoices => _Invoices;
    }
}
