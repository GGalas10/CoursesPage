using Courses.Core.Models.Invoicing;
using Courses.Core.Models.Invoicing.Settings;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;

namespace Courses.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CoursesDbContext _context;
        public InvoiceRepository(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task CreateInvoice(Invoice invoice)
        {
            if (invoice == null)
                throw new Exception("If you want create an invoice, it cannot be empty");
            await Task.FromResult(_context.Invoices.Add(invoice));
            await Task.CompletedTask;
        }
        public Task<Invoice> GetInvoiceByIdAsync(Guid invoiceId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Invoice>> GetUserInvoicesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Invoice>> GetRecipentInvoicesAsync(Guid recipentId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Invoice>> GetBuyerInvoicesAsync(Guid buyerId)
        {
            throw new NotImplementedException();
        }
        public Task EditInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }
        public Task UpdateInvoiceAsync()
        {
            throw new NotImplementedException();
        }
        public Task<InvoiceSettings> GetInvoiceSettings()
        {
            throw new NotImplementedException();
        }     
    }
}
