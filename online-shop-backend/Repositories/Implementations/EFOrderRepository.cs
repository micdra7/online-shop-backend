using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            
            foreach (var orderDetail in order.Details)
            {
                context.Products.Find(orderDetail.ProductID).AvailableQuantity -= orderDetail.Quantity;
            }
            
            context.SaveChanges();
        }

        public void RemoveOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public Order GetOrder(long id)
        {
            return context.Orders.Find(id);
        }

        public ICollection<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public ApplicationUser GetUserForOrder(long id)
        {
            return (ApplicationUser) context.Users.Find(
                context.Orders.Find(id)?.ApplicationUserID
            );
        }

        public ShippingMethod GetShippingMethodForOrder(long id)
        {
            return context.ShippingMethods.Find(
                context.Orders.Find(id)?.ShippingMethodID
            );
        }

        public ICollection<OrderDetail> GetDetailsForOrder(long id)
        {
            return context.OrderDetails.Where(od => od.OrderID == id).ToList();
        }
    }
}