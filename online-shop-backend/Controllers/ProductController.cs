using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers
{
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        
        [HttpGet("{id:required}")]
        public Product Index(long id)
        {
            var result = productRepository.GetProduct(id);
            result.Producer = productRepository.GetProducerForProduct(id);
            result.Category = productRepository.GetCategoryForProduct(id);
            result.Subcategory = productRepository.GetSubcategoryForProduct(id);
            result.Discounts = productRepository.GetDiscountsForProduct(id);
            
            return result;
        }
    }
}