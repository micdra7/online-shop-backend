using System;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class ShippingMethod
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}