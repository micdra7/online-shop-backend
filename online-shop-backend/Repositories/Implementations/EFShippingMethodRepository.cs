using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFShippingMethodRepository : IShippingMethodRepository
    {
        private ApplicationDbContext context;

        public EFShippingMethodRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddShippingMethod(ShippingMethod shippingMethod)
        {
            context.ShippingMethods.Add(shippingMethod);
            context.SaveChanges();
        }

        public void RemoveShippingMethod(ShippingMethod shippingMethod)
        {
            context.ShippingMethods.Remove(shippingMethod);
            context.SaveChanges();
        }

        public void UpdateShippingMethod(ShippingMethod shippingMethod)
        {
            context.ShippingMethods.Update(shippingMethod);
            context.SaveChanges();
        }

        public ShippingMethod GetShippingMethod(int id)
        {
            return context.ShippingMethods.Find(id);
        }

        public ICollection<ShippingMethod> GetAllShippingMethods()
        {
            return context.ShippingMethods.ToList();
        }
    }
}