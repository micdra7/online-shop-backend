using System.Collections.Generic;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void UpdateOrder(Order order);
        Order GetOrder(long id);
        ICollection<Order> GetAllOrders();
        ICollection<Order> GetOrdersForUser(string userId);
        ApplicationUser GetUserForOrder(long id);
        ShippingMethod GetShippingMethodForOrder(long id);
        ICollection<OrderDetail> GetDetailsForOrder(long id);
    }
}