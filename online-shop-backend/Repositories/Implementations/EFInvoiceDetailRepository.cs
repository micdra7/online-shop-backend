using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFInvoiceDetailRepository : IInvoiceDetailRepository
    {
        private ApplicationDbContext context;

        public EFInvoiceDetailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            context.InvoiceDetails.Add(invoiceDetail);
            context.SaveChanges();
        }

        public void RemoveInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            context.InvoiceDetails.Remove(invoiceDetail);
            context.SaveChanges();
        }

        public void UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            context.InvoiceDetails.Update(invoiceDetail);
            context.SaveChanges();
        }

        public InvoiceDetail GetInvoiceDetail(long id)
        {
            return context.InvoiceDetails.Find(id);
        }

        public ICollection<InvoiceDetail> GetAllInvoiceDetails()
        {
            return context.InvoiceDetails.ToList();
        }

        public Invoice GetInvoiceForInvoiceDetail(long id)
        {
            return context.InvoiceDetails.Find(id)?.Invoice;
        }

        public Product GetProductForInvoiceDetail(long id)
        {
            return context.InvoiceDetails.Find(id)?.Product;
        }
    }
}