using System.Collections.Generic;

namespace online_shop_backend.Models.DTO
{
    public class CartDTO
    {
        public ICollection<CartItemDTO> CartItems { get; set; }
        public string Username { get; set; }
        public int ShippingMethodID { get; set; }
        public int PaymentTypeID { get; set; }
        public string Note { get; set; }
    }
}