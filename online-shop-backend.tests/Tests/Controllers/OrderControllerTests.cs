using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Moq;
using Newtonsoft.Json;
using online_shop_backend.Controllers;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
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
        private readonly IShippingMethodRepository shippingMethodRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderControllerTests()
        {
            this.orderRepository = new SampleOrderRepository();
            this.productRepository = new SampleProductRepository();
            this.shippingMethodRepository = new SampleShippingMethodRepository();
            this.paymentTypeRepository = new SamplePaymentTypeRepository();
            this.userManager = TestUtils.CreateUserManager<ApplicationUser>();
            
            this.orderController = new OrderController(orderRepository, productRepository, 
                shippingMethodRepository, paymentTypeRepository, userManager);
        }

        [Fact]
        public void AddsOrderCorrectly()
        {
            var cartObject = new CartDTO
            {
                Note = "Note1",
                ShippingMethodID = 1,
                Username = "User1",
                CartItems = new List<CartItemDTO>
                {
                    new CartItemDTO
                    {
                        ProductID = 1,
                        Quantity = 10
                    }
                }
            };

            var result = orderController.Index(cartObject)?.Result;
            
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
                Username = "User1",
                CartItems = new List<CartItemDTO>
                {
                    new CartItemDTO
                    {
                        ProductID = 1,
                        Quantity = 25
                    }
                }
            };

            var result = orderController.Index(cartObject)?.Result;
            
            Assert.Null(result);
        }

        // only one value in InlineData for now, might add more to sample repository later
        [Theory]
        [InlineData(1)]
        public void ReturnsExistingOrder(long id)
        {
            var result = orderController.GetOrderForId(id);
            
            Assert.Equal(JsonConvert.SerializeObject(orderRepository.GetOrder(id)),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void ReturnsNullIfOrderNotFound()
        {
            var result = orderController.GetOrderForId(1234567890);
            
            Assert.Null(result);
        }

        [Fact]
        public void ReturnsLastOrderedProducts()
        {
            var result = orderController.GetLastOrderedProducts();

            var expectedOrder = orderRepository.GetOrder(1);
            var expectedProducts = (from detail in expectedOrder?.Details select detail.Product).ToList();


            Assert.Equal(JsonConvert.SerializeObject(expectedProducts),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void ReturnsAllShippingMethods()
        {
            var result = orderController.GetShippingMethods();
            
            Assert.Equal(JsonConvert.SerializeObject(shippingMethodRepository.GetAllShippingMethods()),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void ReturnsAllPaymentTypes()
        {
            var result = orderController.GetPaymentTypes();
            
            Assert.Equal(JsonConvert.SerializeObject(paymentTypeRepository.GetAllPaymentTypes()),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void ReturnsOrderHistoryForUser()
        {
            var user = new UserDTO
            {
                Username = "User1"
            };
            
            var result = orderController.OrderHistory(user).Result;
            
            Assert.Equal(JsonConvert.SerializeObject(orderRepository.GetOrdersForUser("1")),
                JsonConvert.SerializeObject(result));
        }
    }
}