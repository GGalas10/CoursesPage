using Courses.Core.Models.Commons;

namespace Courses.Core.Models.Invoicing
{
    public class Recipient
    {
        private readonly List<Invoice> _Invoices;
        public Guid Id { get; protected set; }
        public Guid AdressId { get; protected set; }
        public Address DeliveryAdress { get; protected set; }
        public IEnumerable<Invoice> Invoices => _Invoices;
        private Recipient() { }
        public Recipient(List<Invoice> invoices,Address deliveryAdress)
        {
            _Invoices = invoices;
            Id = Guid.NewGuid();
            SetAdress(deliveryAdress);
        }
        public void SetAdress(Address adress)
        {
            if (adress == null)
                throw new Exception("Adress cannot be null or empty");
            DeliveryAdress = adress;
        }
        public void AddInvoice(Invoice invoice)
        {
            if (invoice == null) 
                throw new Exception("Invoice cannot be null or empty");
            _Invoices.Add(invoice);
        }
    }
}
