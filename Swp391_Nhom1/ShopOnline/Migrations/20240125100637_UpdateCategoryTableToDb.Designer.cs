﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopOnline.Data;

#nullable disable

namespace ShopOnline.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240125100637_UpdateCategoryTableToDb")]
    partial class UpdateCategoryTableToDb
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
                        .HasColumnType("nvarchar(max)");

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
#pragma warning restore 612, 618
        }
    }
}
