using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShopOnline.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Banh", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Keo", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Do uong", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Khacc", DisplayOrder = 4 }
                );
            modelBuilder.Entity<Slider>().HasData(
                new Slider { Id = 1, Name = "sl1", Description = "sl1", ImageUrl = "\\images\\slider\\3465d5e5-3259-4ba1-bed4-dab527431481.png" },
                new Slider { Id = 2, Name = "sl2", Description = "sl2", ImageUrl = "\\images\\slider\\b63cb4d0-bbba-41db-93e4-ff6c5d7d65e9.png" },
                new Slider { Id = 3, Name = "sl3", Description = "sl3", ImageUrl = "\\images\\slider\\c0fd6f84-67f7-4b84-8398-4a98d20968ae.jpg" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Bánh gạo An Tự Nhiên N",
                    Company = "MixiGaming",
                    Description = "From Mixi With Love",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\0c85de81-b4a9-4f22-8038-3bd8c3ff5650.png"

                },
                new Product
                {
                    Id = 2,
                    Name = "Keo aphelibe",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaminggggssssg",
                    SKU = "220909101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = "\\images\\product\\1450932b-2be4-4fb3-90c0-b92218a8f557.jpg"

                },
                new Product
                {
                    Id = 3,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\14b1abde-5c10-4bca-8b03-6b455420aedf.jpg"

                },
                new Product
                {
                    Id = 4,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\301b0b25-267c-4706-a0e5-795139af09a9.jpg"

                },
                new Product
                {
                    Id = 5,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming with love",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\1450932b-2be4-4fb3-90c0-b92218a8f557.jpg"

                },
                new Product
                {
                    Id = 6,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\404631437_282893548080508_6086691714179850617_n.jpg"

                },
                new Product
                {
                    Id = 7,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\41cd4ece-6dce-47aa-8a0f-d9547b03a64c.jpg"

                },
                new Product
                {
                    Id = 8,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\4243412e-9dce-4517-9cb9-d46558b9faf7.jpg"

                },
                new Product
                {
                    Id = 9,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\1450932b-2be4-4fb3-90c0-b92218a8f557.jpg"

                },
                new Product
                {
                    Id = 10,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\5b29925c-33ea-459e-be45-ef69f388748d.jpg"

                },
                new Product
                {
                    Id = 11,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "\\images\\product\\5c2c824d-91a1-4b32-9b61-ff894ef9529e.jpg"

                },
                new Product
                {
                    Id = 12,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 13,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 14,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 15,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 16,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 17,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 18,
                    Name = "Bánh gạo An Tự Nhiên",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 19,
                    Name = "Bánh gạo An Tự Nhiên.",
                    Company = "MixiGaming",
                    Description = "Den tu mixigaming",
                    SKU = "220909100",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                }
                );
        }
    }
}
