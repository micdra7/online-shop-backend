using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SamplePaymentTypeRepository : IPaymentTypeRepository
    {
        private ICollection<PaymentType> PaymentTypes { get; set; }

        public SamplePaymentTypeRepository()
        {
            this.PaymentTypes = new List<PaymentType>
            {
                new PaymentType
                {
                    ID = 1,
                    Name = "PaymentType1"
                }
            };
        }
        
        public void AddPaymentType(PaymentType paymentType)
        {
            PaymentTypes.Add(paymentType);
        }

        public void RemovePaymentType(PaymentType paymentType)
        {
            PaymentTypes.Remove(paymentType);
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {
            PaymentTypes.Remove(PaymentTypes.First(pt => pt.ID == paymentType.ID));
            PaymentTypes.Add(paymentType);
        }

        public PaymentType GetPaymentType(int id)
        {
            return PaymentTypes.FirstOrDefault(pt => pt.ID == id);
        }

        public ICollection<PaymentType> GetAllPaymentTypes()
        {
            return PaymentTypes;
        }
    }
}