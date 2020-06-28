using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleCategoriesRepository : ICategoriesRepository
    {
        private ICollection<Category> Categories { get; set; }
        private ICollection<Product> Products { get; set; }

        public SampleCategoriesRepository()
        {
            this.Categories = new List<Category>
            {
                new Category
                {
                    ID = 1,
                    Name = "Cat1",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            ID = 1,
                            CategoryID = 1,
                            Name = "Sub1"
                        },
                        new Subcategory
                        {
                            ID = 2,
                            CategoryID = 1,
                            Name = "Sub2"
                        }
                    }
                },
                new Category
                {
                    ID = 2,
                    Name = "Cat2",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            ID = 3,
                            CategoryID = 2,
                            Name = "Sub3"
                        },
                        new Subcategory
                        {
                            ID = 4,
                            CategoryID = 2,
                            Name = "Sub4"
                        }
                    }
                }
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

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            Categories.Remove(Categories.First(cat => cat.ID == category.ID));
            Categories.Add(category);
        }

        public Category GetCategory(int id)
        {
            return Categories.FirstOrDefault(cat => cat.ID == id);
        }

        public ICollection<Category> GetAllCategories()
        {
            return Categories;
        }

        public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
        {
            return Categories.FirstOrDefault(cat => cat.ID == id)?.Subcategories;
        }

        public ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20)
        {
            return Products.Where(p => p.CategoryID == id).ToList();
        }
    }
}