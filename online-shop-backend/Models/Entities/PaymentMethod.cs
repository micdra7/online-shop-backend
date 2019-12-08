using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities
{
    public class PaymentMethod
    {
        public long ID { get; set; }
        
        public int PaymentTypeID { get; set; }
        
        public long ApplicationUserID { get; set; }
        
        [Required]
        [StringLength(512)]
        public string Value { get; set; }
        
        public PaymentType PaymentType { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}