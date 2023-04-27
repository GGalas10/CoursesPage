using Courses.Core.Models.Common;

namespace Courses.Core.Models.Invoicing
{
    public class Buyer
    {
        private readonly List<Invoice> _Invoices;
        public Guid Id { get;protected set; }
        public string Name { get; protected set; }
        public Address Adress { get; protected set; }
        public string NIN { get; protected set; }
        public virtual IEnumerable<Invoice> Invoices => _Invoices;
        private Buyer() { }
        public Buyer(string name, Address adress, string nIN,List<Invoice>? invoices)
        {
            Id = Guid.NewGuid();
            if(invoices.Count <=0)
                invoices = new List<Invoice>();
            SetInvoices(invoices);
            SetName(name);
            SetAdress(adress);
            SetNIN(nIN);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            Name = name.Trim();
        }
        public void SetAdress(Address adress)
        {
            if (adress == null) 
                throw new Exception("Adress cannot be empty");
            Adress = adress;
        }
        public void SetNIN(string nIN)
        {
            if (nIN == null) 
                throw new Exception("NIN cannot be empty");
            NIN = nIN.Trim();
        }
        public void SetInvoice(Invoice invoice)
        {
            if (invoice == null) 
                throw new Exception("Invoice cannot be empty");
            _Invoices.Add(invoice);
        }
        public void SetInvoices(List<Invoice> invoices)
        {
            if (invoices.Count <= 0)
                throw new Exception("Invoices cannot be empty");
            _Invoices.AddRange(invoices);
        }
    }
}
