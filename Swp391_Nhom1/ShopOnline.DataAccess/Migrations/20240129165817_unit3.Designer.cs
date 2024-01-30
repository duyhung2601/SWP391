﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopOnline.DataAccess.Data;

#nullable disable

namespace ShopOnline.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240129165817_unit3")]
    partial class unit3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopOnline.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Banh"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Keo"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Do uong"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Khac"
                        });
                });

            modelBuilder.Entity("ShopOnline.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Company = "MixiGaming",
                            Description = "Den tu mixigaming",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Name = "Bánh gạo An Tự Nhiênnn",
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            SKU = "220909100"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Company = "MixiGaming",
                            Description = "Den tu mixigaming",
                            ImageUrl = "",
                            ListPrice = 30.0,
                            Name = "Keo aphelibe",
                            Price = 27.0,
                            Price100 = 20.0,
                            Price50 = 25.0,
                            SKU = "220909101"
                        });
                });

            modelBuilder.Entity("ShopOnline.Models.Product", b =>
                {
                    b.HasOne("ShopOnline.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
