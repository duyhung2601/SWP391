﻿using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Banh", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Keo", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Do uong", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Khac", DisplayOrder = 4 }
                );
        }
    }
}
