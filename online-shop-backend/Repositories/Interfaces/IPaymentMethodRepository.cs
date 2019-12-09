using System.Collections.Generic;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        void AddPaymentMethod(PaymentMethod paymentMethod);
        void RemovePaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        PaymentMethod GetPaymentMethod(long id);
        ICollection<PaymentMethod> GetAllPaymentMethods();
        PaymentType GetTypeForPaymentMethod(long id);
        ApplicationUser GetUserForPaymentMethod(long id);
    }
}