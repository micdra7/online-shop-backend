using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleShippingMethodRepository : IShippingMethodRepository
    {
        private ICollection<ShippingMethod> ShippingMethods { get; set; }

        public SampleShippingMethodRepository()
        {
            this.ShippingMethods = new List<ShippingMethod>
            {
                new ShippingMethod
                {
                    ID = 1,
                    Name = "Method1",
                    Price = 2.99m
                },
                new ShippingMethod
                {
                    ID = 2,
                    Name = "Method2",
                    Price = 4.99m
                }
            };
        }
        
        public void AddShippingMethod(ShippingMethod shippingMethod)
        {
            ShippingMethods.Add(shippingMethod);
        }

        public void RemoveShippingMethod(ShippingMethod shippingMethod)
        {
            ShippingMethods.Remove(shippingMethod);
        }

        public void UpdateShippingMethod(ShippingMethod shippingMethod)
        {
            ShippingMethods.Remove(ShippingMethods.First(sm => sm.ID == shippingMethod.ID));
            ShippingMethods.Add(shippingMethod);
        }

        public ShippingMethod GetShippingMethod(int id)
        {
            return ShippingMethods.FirstOrDefault(sm => sm.ID == id);
        }

        public ICollection<ShippingMethod> GetAllShippingMethods()
        {
            return ShippingMethods;
        }
    }
}