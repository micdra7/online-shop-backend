using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFSubcategoriesRepository : ISubcategoriesRepository
    {
        private ApplicationDbContext context;

        public EFSubcategoriesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddSubcategory(Subcategory subcategory)
        {
            context.Subcategories.Add(subcategory);
            context.SaveChanges();
        }

        public void RemoveSubcategory(Subcategory subcategory)
        {
            context.Subcategories.Remove(subcategory);
            context.SaveChanges();
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            context.Subcategories.Update(subcategory);
            context.SaveChanges();
        }

        public Subcategory GetSubcategory(int id)
        {
            return context.Subcategories.Find(id);
        }

        public ICollection<Subcategory> GetAllSubcategories()
        {
            return context.Subcategories.ToList();
        }

        public Category GetCategoryForSubcategory(int id)
        {
            return context.Categories.First(
                c => c.Subcategories.Contains(context.Subcategories.Find(id)));
        }

        public ICollection<Product> GetProductsForSubcategory(int id, int page = 1, int limit = 20)
        {
            return context.Products.Where(p => p.SubcategoryID == id)
                .Skip((page - 1) * limit).Take(limit)
                .ToList();
        }
    }
}