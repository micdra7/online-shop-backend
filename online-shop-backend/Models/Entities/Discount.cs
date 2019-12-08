using System;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class Discount
    {
        public long ID { get; set; }
        
        public long ProductID { get; set; }
        
        [Required]
        public decimal Percentage { get; set; }
        
        public DateTime StartTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }
        
        public Product Product { get; set; }
    }
}