using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities
{
    public class Order
    {
        public long ID { get; set; }
        
        public string ApplicationUserID { get; set; }
        
        public int ShippingMethodID { get; set; }
        
        [Required]
        public DateTime DateAndTime { get; set; }
        
        [StringLength(400)]
        public string Note { get; set; }
        
        public decimal ShippingMethodPrice { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        
    }
}