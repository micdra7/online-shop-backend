using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleProductRepository : IProductRepository
    {
        private ICollection<Product> Products { get; set; }

        public SampleProductRepository()
        {
            this.Products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Product1",
                    AvailableQuantity = 10,
                    Price = 15.5m,
                    CategoryID = 1,
                    Category = new Category
                    {
                        ID = 1,
                        Name = "Cat1"
                    },
                    SubcategoryID = 1,
                    Subcategory = new Subcategory
                    {
                        ID = 1,
                        Name = "Sub1",
                        CategoryID = 1
                    },
                    ProducerID = 1,
                    Producer = new Producer
                    {
                        ID = 1,
                        Name = "Producer1"
                    }
                },
                new Product
                {
                    ID = 2,
                    Name = "Product2",
                    AvailableQuantity = 20,
                    Price = 25.5m,
                    CategoryID = 2,
                    Category = new Category
                    {
                        ID = 2,
                        Name = "Cat2"
                    },
                    SubcategoryID = 3,
                    Subcategory = new Subcategory
                    {
                        ID = 3,
                        Name = "Sub3",
                        CategoryID = 2
                    },
                    ProducerID = 2,
                    Producer = new Producer
                    {
                        ID = 2,
                        Name = "Producer2"
                    }
                }
            };
        }
        
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            Products.Remove(Products.First(p => p.ID == product.ID));
            Products.Add(product);
        }

        public Product GetProduct(long id)
        {
            return Products.First(p => p.ID == id);
        }

        public ICollection<Product> GetAllProducts()
        {
            return Products;
        }

        public Producer GetProducerForProduct(long id)
        {
            return Products.First(p => p.ID == id)?.Producer;
        }

        public Category GetCategoryForProduct(long id)
        {
            return Products.First(p => p.ID == id)?.Category;
        }

        public Subcategory GetSubcategoryForProduct(long id)
        {
            return Products.First(p => p.ID == id)?.Subcategory;
        }

        public ICollection<Review> GetReviewsForProduct(long id)
        {
            return Products.First(p => p.ID == id)?.Reviews;
        }

        public ICollection<Discount> GetDiscountsForProduct(long id)
        {
            return Products.First(p => p.ID == id)?.Discounts;
        }

        public bool CheckIfProductIsAvailable(long id, int neededQuantity = 0)
        {
            return Products.First(p => p.ID == id).AvailableQuantity >= neededQuantity;
        }
    }
}