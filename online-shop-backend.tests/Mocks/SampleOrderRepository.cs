using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleOrderRepository : IOrderRepository
    {
        private ICollection<Order> Orders { get; set; }

        public SampleOrderRepository()
        {
            this.Orders = new List<Order>
            {
                new Order
                {
                    ID = 1,
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "1",
                        UserName = "User1",
                        Email = "User1@email.com"
                    },
                    ShippingMethod = new ShippingMethod
                    {
                        ID = 1,
                        Name = "Method1",
                        Price = 2.99m
                    },
                    Note = "Sample note",
                    ShippingMethodPrice = 2.99m,
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ID = 1,
                            OrderID = 1,
                            Quantity = 5,
                            UnitPrice = 15.5m,
                            ProductID = 1,
                            Product = new Product
                            {
                                ID = 1,
                                Name = "Product1",
                                AvailableQuantity = 10,
                                Price = 15.5m,
                                CategoryID = 1,
                                Category = new Category
                                {
                                    ID = 1,
                                    Name = "Cat1"
                                },
                                SubcategoryID = 1,
                                Subcategory = new Subcategory
                                {
                                    ID = 1,
                                    Name = "Sub1",
                                    CategoryID = 1
                                },
                                ProducerID = 1,
                                Producer = new Producer
                                {
                                    ID = 1,
                                    Name = "Producer1",
                                }
                            }
                        }
                    }
                }
            };
        }
        
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            Orders.Remove(Orders.First(o => o.ID == order.ID));
            Orders.Add(order);
        }

        public Order GetOrder(long id)
        {
            return Orders.FirstOrDefault(o => o.ID == id);
        }

        public ICollection<Order> GetAllOrders()
        {
            return Orders;
        }

        public ICollection<Order> GetOrdersForUser(string userId)
        {
            return Orders.Where(o => o.ApplicationUser.Id == userId).ToList();
        }

        public ApplicationUser GetUserForOrder(long id)
        {
            return GetOrder(id).ApplicationUser;
        }

        public ShippingMethod GetShippingMethodForOrder(long id)
        {
            return GetOrder(id).ShippingMethod;
        }

        public ICollection<OrderDetail> GetDetailsForOrder(long id)
        {
            return GetOrder(id).Details;
        }
    }
}