using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleSubcategoriesRepository : ISubcategoriesRepository
    {
        private ICollection<Subcategory> Subcategories { get; set; }
        private ICollection<Product> Products { get; set; }

        public SampleSubcategoriesRepository()
        {
            this.Subcategories = new List<Subcategory>
            {
                new Subcategory
                {
                    ID = 1,
                    Name = "Sub1",
                    CategoryID = 1,
                    Category = new Category
                    {
                        ID = 1,
                        Name = "Cat1"
                    }
                },
                new Subcategory
                {
                    ID = 3,
                    Name = "Sub3",
                    CategoryID = 2,
                    Category = new Category
                    {
                        ID = 2,
                        Name = "Cat2"
                    }
                },
            };
            
            this.Products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Product1",
                    AvailableQuantity = 10,
                    Price = 15.5m,
                    CategoryID = 1,
                    SubcategoryID = 1,
                    ProducerID = 1
                },
                new Product
                {
                    ID = 2,
                    Name = "Product2",
                    AvailableQuantity = 20,
                    Price = 25.5m,
                    CategoryID = 2,
                    SubcategoryID = 3,
                    ProducerID = 2
                }
            };
        }
        
        public void AddSubcategory(Subcategory subcategory)
        {
            Subcategories.Add(subcategory);
        }

        public void RemoveSubcategory(Subcategory subcategory)
        {
            Subcategories.Remove(subcategory);
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            Subcategories.Remove(Subcategories.First(sub => sub.ID == subcategory.ID));
            Subcategories.Add(subcategory);
        }

        public Subcategory GetSubcategory(int id)
        {
            return Subcategories.FirstOrDefault(sub => sub.ID == id);
        }

        public ICollection<Subcategory> GetAllSubcategories()
        {
            return Subcategories;
        }

        public Category GetCategoryForSubcategory(int id)
        {
            return Subcategories.FirstOrDefault(sub => sub.ID == id)?.Category;
        }

        public ICollection<Product> GetProductsForSubcategory(int id, int page = 1, int limit = 20)
        {
            return Products.Where(p => p.SubcategoryID == id).ToList();
        }
    }
}