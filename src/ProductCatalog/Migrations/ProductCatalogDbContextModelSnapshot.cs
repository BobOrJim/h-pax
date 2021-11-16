﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCatalog.DbContexts;

namespace ProductCatalog.Migrations
{
    [DbContext(typeof(ProductCatalogDbContext))]
    partial class ProductCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductCatalog.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Product name");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Description = "Movie 1",
                            ImageUrl = "SomeURL",
                            Name = "Reservoir Dogs",
                            Price = 21
                        },
                        new
                        {
                            ProductId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            Description = "Movie 2",
                            ImageUrl = "SomeURL",
                            Name = "True Romance",
                            Price = 22
                        },
                        new
                        {
                            ProductId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            Description = "Movie 3",
                            ImageUrl = "SomeURL",
                            Name = "Pulp Fiction",
                            Price = 23
                        },
                        new
                        {
                            ProductId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 4",
                            ImageUrl = "SomeURL",
                            Name = "Natural BornKillers",
                            Price = 24
                        },
                        new
                        {
                            ProductId = new Guid("1098f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 5",
                            ImageUrl = "SomeURL",
                            Name = "From Dusk Till Dawn",
                            Price = 25
                        },
                        new
                        {
                            ProductId = new Guid("1198f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 6",
                            ImageUrl = "SomeURL",
                            Name = "Jackie Brown",
                            Price = 26
                        },
                        new
                        {
                            ProductId = new Guid("1298f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 7",
                            ImageUrl = "SomeURL",
                            Name = "Inglourious Basterds",
                            Price = 27
                        },
                        new
                        {
                            ProductId = new Guid("1398f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 8",
                            ImageUrl = "SomeURL",
                            Name = "Django Unchained",
                            Price = 28
                        },
                        new
                        {
                            ProductId = new Guid("1498f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 9",
                            ImageUrl = "SomeURL",
                            Name = "The Hateful Eight",
                            Price = 29
                        },
                        new
                        {
                            ProductId = new Guid("1598f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Description = "Movie 10",
                            ImageUrl = "SomeURL",
                            Name = "Once Upon a Time In Hollywood",
                            Price = 30
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
