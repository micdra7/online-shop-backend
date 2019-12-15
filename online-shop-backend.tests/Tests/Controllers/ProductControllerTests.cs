using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using online_shop_backend.Controllers;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly ProductController productController;
        private readonly IProductRepository productRepository;
        private readonly IDiscountRepository discountRepository;

        public ProductControllerTests()
        {
            this.productRepository = new SampleProductRepository();
            this.discountRepository = new SampleDiscountRepository();
            this.productController = new ProductController(productRepository, discountRepository);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReturnsProduct(long id)
        {
            var result = productController.Index(id);

            var expected = productRepository.GetProduct(id);
            
            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void ReturnsAllDiscounts()
        {
            var result = productController.Discounts();
            
            Assert.Equal(JsonConvert.SerializeObject(discountRepository.GetAllDiscounts()),
                JsonConvert.SerializeObject(result));
        }
    }
}