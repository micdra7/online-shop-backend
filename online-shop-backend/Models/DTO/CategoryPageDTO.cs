using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Models.DTO
{
    public class CategoryPageDTO
    {
        public Category Category { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}