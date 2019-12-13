using Newtonsoft.Json;
using online_shop_backend.Controllers;
using online_shop_backend.Models.DTO;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class CategoryControllerTests
    {
        private readonly CategoryController controller;
        private readonly ICategoriesRepository categoriesRepository;

        public CategoryControllerTests()
        {
            this.categoriesRepository = new SampleCategoriesRepository();
            this.controller = new CategoryController(categoriesRepository);
        }

        [Fact]
        public void ReturnsAListOfAllCategories()
        {
            var result = controller.Index();
            
            Assert.Equal(JsonConvert.SerializeObject(categoriesRepository.GetAllCategories()),
                JsonConvert.SerializeObject(result));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReturnsCategoryAndItsSubcategoriesAndProducts(int id)
        {
            var result = controller.Category(id, null, null);

            var expected = new CategoryPageDTO
            {
                Category = categoriesRepository.GetCategory(id),
                Subcategories = categoriesRepository.GetSubcategoriesForCategory(id),
                Products = categoriesRepository.GetProductsForCategory(id)
            };
            
            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(result));
        }
    }
}