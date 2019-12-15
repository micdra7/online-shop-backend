using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using online_shop_backend.Controllers;
using online_shop_backend.Models.DTO;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly OrderController orderController;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderControllerTests()
        {
            this.orderRepository = new SampleOrderRepository();
            this.productRepository = new SampleProductRepository();
            this.orderController = new OrderController(orderRepository, productRepository);
        }

        [Fact]
        public void AddsOrderCorrectly()
        {
            var cartObject = new CartDTO
            {
                Note = "Note1",
                ShippingMethodID = 1,
                UserID = "1",
                CartItems = new List<CartItemDTO>
                {
                    new CartItemDTO
                    {
                        ProductID = 1,
                        Quantity = 10
                    }
                }
            };

            var result = orderController.Index(cartObject);
            
            Assert.Equal(JsonConvert.SerializeObject(orderRepository.GetAllOrders().Last()),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void DoesNotAddOrderIfProductIsNotAvailable()
        {
            var cartObject = new CartDTO
            {
                Note = "Note1",
                ShippingMethodID = 1,
                UserID = "1",
                CartItems = new List<CartItemDTO>
                {
                    new CartItemDTO
                    {
                        ProductID = 1,
                        Quantity = 25
                    }
                }
            };

            var result = orderController.Index(cartObject);
            
            Assert.Null(result);
        }
    }
}