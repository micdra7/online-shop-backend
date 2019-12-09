using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFPaymentTypeRepository : IPaymentTypeRepository
    {
        private ApplicationDbContext context;

        public EFPaymentTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddPaymentType(PaymentType paymentType)
        {
            context.PaymentTypes.Add(paymentType);
            context.SaveChanges();
        }

        public void RemovePaymentType(PaymentType paymentType)
        {
            context.PaymentTypes.Remove(paymentType);
            context.SaveChanges();
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {
            context.PaymentTypes.Update(paymentType);
            context.SaveChanges();
        }

        public PaymentType GetPaymentType(int id)
        {
            return context.PaymentTypes.Find(id);
        }

        public ICollection<PaymentType> GetAllPaymentTypes()
        {
            return context.PaymentTypes.ToList();
        }
    }
}