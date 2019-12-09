using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        void AddDiscount(Discount discount);
        void RemoveDiscount(Discount discount);
        void UpdateDiscount(Discount discount);
        Discount GetDiscount(long id);
        ICollection<Discount> GetAllDiscounts();
        Product GetProductForDiscount(long id);
    }
}