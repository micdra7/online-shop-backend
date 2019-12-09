using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private ApplicationDbContext context;

        public EFInvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

        public void RemoveInvoice(Invoice invoice)
        {
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            context.Invoices.Update(invoice);
            context.SaveChanges();
        }

        public Invoice GetInvoice(long id)
        {
            return context.Invoices.Find(id);
        }

        public ICollection<Invoice> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }

        public ApplicationUser GetUserForInvoice(long id)
        {
            return context.Invoices.Find(id)?.ApplicationUser;
        }

        public Order GetOrderForInvoice(long id)
        {
            return context.Invoices.Find(id)?.Order;
        }

        public ICollection<InvoiceDetail> GetDetailsForInvoice(long id)
        {
            return context.Invoices.Find(id)?.Details;
        }
    }
}