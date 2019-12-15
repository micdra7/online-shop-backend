using System;
using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleDiscountRepository : IDiscountRepository
    {
        private ICollection<Discount> Discounts { get; set; }

        public SampleDiscountRepository()
        {
            this.Discounts = new List<Discount>
            {
                new Discount
                {
                    ID = 1,
                    Percentage = 10m,
                    ProductID = 1,
                    Product = new Product
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
                    StartTime = DateTime.Now,
                    EndTime = DateTime.ParseExact("31/12/2090", "dd/MM/yyyy", null)
                }
            };   
        }
        
        public void AddDiscount(Discount discount)
        {
            Discounts.Add(discount);
        }

        public void RemoveDiscount(Discount discount)
        {
            Discounts.Remove(discount);
        }

        public void UpdateDiscount(Discount discount)
        {
            Discounts.Remove(Discounts.First(d => d.ID == discount.ID));
            Discounts.Add(discount);
        }

        public Discount GetDiscount(long id)
        {
            return Discounts.First(d => d.ID == id);
        }

        public ICollection<Discount> GetAllDiscounts()
        {
            return Discounts;
        }

        public Product GetProductForDiscount(long id)
        {
            return GetDiscount(id).Product;
        }
    }
}