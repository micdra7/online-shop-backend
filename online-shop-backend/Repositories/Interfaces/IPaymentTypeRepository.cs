using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IPaymentTypeRepository
    {
        void AddPaymentType(PaymentType paymentType);
        void RemovePaymentType(PaymentType paymentType);
        void UpdatePaymentType(PaymentType paymentType);
        PaymentType GetPaymentType(int id);
        ICollection<PaymentType> GetAllPaymentTypes();
    }
}