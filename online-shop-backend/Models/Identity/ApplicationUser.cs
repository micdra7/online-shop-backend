using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserDetail> Details { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}