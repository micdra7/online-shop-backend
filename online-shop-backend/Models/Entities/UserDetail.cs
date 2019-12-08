using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities
{
    public class UserDetail
    {
        public long ID { get; set; }
        
        public string UserID { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Surname { get; set; }
        
        [StringLength(200)]
        public string Address1 { get; set; }
        
        [StringLength(200)]
        public string Address2 { get; set; }
        
        [StringLength(200)]
        public string Address3 { get; set; }
        
        [StringLength(32)]
        public string ZipCode { get; set; }
        
        [StringLength(200)]
        public string City { get; set; }
        
        [StringLength(200)]
        public string Country { get; set; }
        
        [StringLength(200)]
        public string StateRegion { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}