using System.Collections.Generic;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        void AddInvoice(Invoice invoice);
        void RemoveInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        Invoice GetInvoice(long id);
        ICollection<Invoice> GetAllInvoices();
        ApplicationUser GetUserForInvoice(long id);
        Order GetOrderForInvoice(long id);
        ICollection<InvoiceDetail> GetDetailsForInvoice(long id);
    }
}