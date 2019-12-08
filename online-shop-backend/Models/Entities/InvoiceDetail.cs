namespace online_shop_backend.Models.Entities
{
    public class InvoiceDetail
    {
        public long ID { get; set; }
        
        public long InvoiceID { get; set; }
        
        public long ProductID { get; set; }
        
        public int ItemQuantity { get; set; }
        
        public decimal ItemPrice { get; set; }
        
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}