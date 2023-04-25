using Courses.Core.Models.Invoicing;
using Courses.Core.Models.Invoicing.Settings;

namespace Courses.Core.Repositories
{
    public interface IInvoiceRepository
    {
        Task CreateInvoice(Invoice invoice);
        Task<Invoice> GetInvoiceByIdAsync(Guid invoiceId);
        Task<List<Invoice>> GetUserInvoicesAsync(Guid userId);
        Task<List<Invoice>> GetRecipentInvoicesAsync(Guid recipentId);
        Task<List<Invoice>> GetBuyerInvoicesAsync(Guid buyerId);
        Task EditInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync();
        Task<InvoiceSettings> GetInvoiceSettings();

    }
}
