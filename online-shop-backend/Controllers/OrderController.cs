using System;
using System.Collections.Generic;
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
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }
        
        [HttpPost]
//        [Authorize(Roles = )]
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
    }
}