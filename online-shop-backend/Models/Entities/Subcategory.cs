using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class Subcategory
    {
        public int ID { get; set; }
        
        public int CategoryID { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        public Category Category { get; set; }
    }
}