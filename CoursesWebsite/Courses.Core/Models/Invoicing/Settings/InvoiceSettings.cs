namespace Courses.Core.Models.Invoicing.Settings
{
    public class InvoiceSettings
    {
        public int InvoicingNumber { get; protected set; }
        public string InvoiceEnd { get; protected set; }
        private InvoiceSettings() { }
        public InvoiceSettings(int invoicingNumber, string? invoiceEnd)
        {
            SetNumber(invoicingNumber);
            SetEnd(invoiceEnd);
        }
        public void SetNumber(int number)
        {
            if (number <= 0)
                throw new Exception("Invoice number cannot be equal or less than 0");
            InvoicingNumber = number;
        }
        public void SetEnd(string? end)
        {
            if(string.IsNullOrEmpty(end))
                InvoiceEnd ="/"+DateTime.Now.Year.ToString();
            InvoiceEnd = end;
        }
    }
}
