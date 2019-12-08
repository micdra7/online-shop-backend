namespace online_shop_backend.Models.Entities
{
    public class OrderDetail
    {
        public long ID { get; set; }
        
        public long OrderID { get; set; }
        
        public long ProductID { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}