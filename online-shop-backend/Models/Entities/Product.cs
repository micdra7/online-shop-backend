using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class Product
    {
        public long ID { get; set; }
        
        public int ProducerID { get; set; }
        
        public int CategoryID { get; set; }
        
        public int SubcategoryID { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int AvailableQuantity { get; set; }

        public Producer Producer { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}