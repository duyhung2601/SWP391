using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;

namespace ShopOnline.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Banh", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Keo", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Do uong", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Khac", DisplayOrder = 4 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Name= "Bánh gạo  Tự Nhiên",
                    Company ="MixiGaming",
                    Description="Den tu mixigaming",
                    SKU= "220909100",
                    ListPrice=99,
                    Price=90,
                    Price50=85,
                    Price100=80,
                    CategoryId=1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Name = "Keo aphelibe ",
                    Company = "MixiGaminggg",
                    Description = "Den tu mixigaming",
                    SKU = "220909101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl=""

                }
                );
        }
    }
}
