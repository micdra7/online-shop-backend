using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Models.Identity
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerDetail> ProducerDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UserDetail>().ToTable("user_details");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Producer>().ToTable("producers");
            modelBuilder.Entity<ProducerDetail>().ToTable("producer_details");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderDetail>().ToTable("order_details");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Subcategory>().ToTable("subcategories");
            modelBuilder.Entity<PaymentType>().ToTable("payment_types");
            modelBuilder.Entity<PaymentMethod>().ToTable("payment_methods");
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<ShippingMethod>().ToTable("shipping_methods");
            modelBuilder.Entity<Invoice>().ToTable("invoices");
            modelBuilder.Entity<InvoiceDetail>().ToTable("invoice_details");
            modelBuilder.Entity<Discount>().ToTable("discounts");
            modelBuilder.Entity<RefreshToken>().ToTable("refresh_tokens");
        }
    }
}