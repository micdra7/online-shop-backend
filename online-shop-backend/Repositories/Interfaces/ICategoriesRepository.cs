using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategory(int id);
        ICollection<Category> GetAllCategories();
        ICollection<Subcategory> GetSubcategoriesForCategory(int id);
        ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20);
    }
}