namespace Courses.Core.Models.Invoicing.Settings
{
    public class InvoiceSettings
    {
        public int InvoicingNumber { get; protected set; }
        public string? InvoiceEnd { get; protected set; }
        private InvoiceSettings() { }
        public InvoiceSettings(int invoicingNumber, string? invoiceEnd)
        {
            InvoicingNumber = invoicingNumber;
            InvoiceEnd = invoiceEnd;
        }
    }
}
