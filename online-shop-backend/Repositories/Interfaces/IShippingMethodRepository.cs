using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IShippingMethodRepository
    {
        void AddShippingMethod(ShippingMethod shippingMethod);
        void RemoveShippingMethod(ShippingMethod shippingMethod);
        void UpdateShippingMethod(ShippingMethod shippingMethod);
        ShippingMethod GetShippingMethod(int id);
        ICollection<ShippingMethod> GetAllShippingMethods();
    }
}