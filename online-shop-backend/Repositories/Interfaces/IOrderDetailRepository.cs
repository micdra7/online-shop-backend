using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(OrderDetail orderDetail);
        void RemoveOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        OrderDetail GetOrderDetail(long id);
        ICollection<OrderDetail> GetAllOrderDetails();
        Order GetOrderForOrderDetail(long id);
        Product GetProductForOrderDetail(long id);
    }
}