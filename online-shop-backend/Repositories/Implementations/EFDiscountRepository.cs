using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFDiscountRepository : IDiscountRepository
    {
        private ApplicationDbContext context;

        public EFDiscountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddDiscount(Discount discount)
        {
            context.Discounts.Add(discount);
            context.SaveChanges();
        }

        public void RemoveDiscount(Discount discount)
        {
            context.Discounts.Remove(discount);
            context.SaveChanges();
        }

        public void UpdateDiscount(Discount discount)
        {
            context.Discounts.Update(discount);
            context.SaveChanges();
        }

        public Discount GetDiscount(long id)
        {
            return context.Discounts.Find(id);
        }

        public ICollection<Discount> GetAllDiscounts()
        {
            return context.Discounts.ToList();
        }

        public Product GetProductForDiscount(long id)
        {
            return context.Discounts.Find(id)?.Product;
        }
    }
}