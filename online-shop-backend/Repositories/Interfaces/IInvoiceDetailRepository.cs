using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        void AddInvoiceDetail(InvoiceDetail invoiceDetail);
        void RemoveInvoiceDetail(InvoiceDetail invoiceDetail);
        void UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
        InvoiceDetail GetInvoiceDetail(long id);
        ICollection<InvoiceDetail> GetAllInvoiceDetails();
        Invoice GetInvoiceForInvoiceDetail(long id);
        Product GetProductForInvoiceDetail(long id);
    }
}