using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.Data
{
    public class ShopOnlineContext : DbContext
    {
        public ShopOnlineContext (DbContextOptions<ShopOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetail { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od=>  new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetail>().ToTable("Order_Details");
        }
        public DbSet<ShopOnline.Models.Product>? Product {  get; set; }
        public DbSet<ShopOnline.Models.Order>? Order {  get; set; } 
        
    }
}
