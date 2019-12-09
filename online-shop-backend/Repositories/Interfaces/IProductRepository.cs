using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProduct(long id);
        ICollection<Product> GetAllProducts();
        Producer GetProducerForProduct(long id);
        Category GetCategoryForProduct(long id);
        Subcategory GetSubcategoryForProduct(long id);
        ICollection<Review> GetReviewsForProduct(long id);
        ICollection<Discount> GetDiscountsForProduct(long id);
    }
}