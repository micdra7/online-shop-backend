using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers
{
    [Route("/api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }
        
        [HttpPost]
        [Authorize]
        public Order Index([FromBody] CartDTO cart)
        {
            var orderToAdd = new Order
            {
                ApplicationUserID = cart.UserID,
                ShippingMethodID = cart.ShippingMethodID,
                Note = cart.Note,
                DateAndTime = DateTime.Now,
                Details = new List<OrderDetail>()
            };

            foreach (var item in cart.CartItems)
            {
                if (!productRepository.CheckIfProductIsAvailable(item.ProductID, item.Quantity))
                {
                    return null;
                }
                
                orderToAdd.Details.Add(new OrderDetail
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = productRepository.GetProduct(item.ProductID).Price
                });
            }
            
            orderRepository.AddOrder(orderToAdd);
            
            return orderToAdd;
        }

        [HttpGet("last")]
        public List<Product> GetLastOrderedProducts()
        {
            var lastOrders = orderRepository.GetAllOrders().Take(3);

            var productsToReturn = new List<Product>();

            var orders = lastOrders.ToList();
            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    foreach (var detail in orderRepository.GetDetailsForOrder(order.ID))
                    {
                        productsToReturn.Add(
                            productRepository.GetProduct(detail.ProductID));
                    }
                }
            }
            
            return productsToReturn.Take(4).ToList();
        }
    }
}