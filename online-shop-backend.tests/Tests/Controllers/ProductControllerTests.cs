using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using online_shop_backend.Controllers;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly ProductController productController;
        private readonly SampleProductRepository productRepository;

        public ProductControllerTests()
        {
            this.productRepository = new SampleProductRepository();
            this.productController = new ProductController(productRepository);
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
    }
}