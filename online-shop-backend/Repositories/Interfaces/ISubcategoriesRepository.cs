using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface ISubcategoriesRepository
    {
        void AddSubcategory(Subcategory subcategory);
        void RemoveSubcategory(Subcategory subcategory);
        void UpdateSubcategory(Subcategory subcategory);
        Subcategory GetSubcategory(int id);
        ICollection<Subcategory> GetAllSubcategories();
        Category GetCategoryForSubcategory(int id);
    }
}