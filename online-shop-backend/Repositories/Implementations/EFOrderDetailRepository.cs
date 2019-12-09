using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        private ApplicationDbContext context;

        public EFOrderDetailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Remove(orderDetail);
            context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Update(orderDetail);
            context.SaveChanges();
        }

        public OrderDetail GetOrderDetail(long id)
        {
            return context.OrderDetails.Find(id);
        }

        public ICollection<OrderDetail> GetAllOrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        public Order GetOrderForOrderDetail(long id)
        {
            return context.OrderDetails.Find(id)?.Order;
        }

        public Product GetProductForOrderDetail(long id)
        {
            return context.OrderDetails.Find(id)?.Product;
        }
    }
}