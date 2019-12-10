using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private ApplicationDbContext context;

        public EFCategoriesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Find(id);
        }

        public ICollection<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
        {
            return context.Subcategories.Where(s => s.CategoryID == id).ToList();
        }
    }
}