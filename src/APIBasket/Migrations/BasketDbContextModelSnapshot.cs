// <auto-generated />
using System;
using APIBasket.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIBasket.Migrations
{
    [DbContext(typeof(BasketDbContext))]
    partial class BasketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIBasket.Entities.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            BasketId = new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            UserId = new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde")
                        },
                        new
                        {
                            BasketId = new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"),
                            UserId = new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde")
                        },
                        new
                        {
                            BasketId = new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            UserId = new Guid("2398f549-e790-4e9f-aa16-18c2292a2ee9")
                        });
                });

            modelBuilder.Entity("APIBasket.Entities.BasketLine", b =>
                {
                    b.Property<Guid>("BasketLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketLineId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketLines");

                    b.HasData(
                        new
                        {
                            BasketLineId = new Guid("a94d70c5-1217-463b-b318-93679084bada"),
                            Amount = 1,
                            BasketId = new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 21,
                            ProductId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde")
                        },
                        new
                        {
                            BasketLineId = new Guid("b94d70c5-1217-463b-b318-93679084bada"),
                            Amount = 2,
                            BasketId = new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 22,
                            ProductId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6")
                        },
                        new
                        {
                            BasketLineId = new Guid("c94d70c5-1217-463b-b318-93679084bada"),
                            Amount = 1,
                            BasketId = new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 23,
                            ProductId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa")
                        },
                        new
                        {
                            BasketLineId = new Guid("972b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 3,
                            BasketId = new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"),
                            Price = 24,
                            ProductId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            BasketLineId = new Guid("a72b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 1,
                            BasketId = new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"),
                            Price = 25,
                            ProductId = new Guid("1098f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            BasketLineId = new Guid("b72b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 1,
                            BasketId = new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"),
                            Price = 26,
                            ProductId = new Guid("1198f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            BasketLineId = new Guid("c72b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 1,
                            BasketId = new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 27,
                            ProductId = new Guid("1298f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            BasketLineId = new Guid("d72b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 1,
                            BasketId = new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 28,
                            ProductId = new Guid("1398f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            BasketLineId = new Guid("e72b1de4-fd41-4d6d-8d7a-cf80219e60d7"),
                            Amount = 1,
                            BasketId = new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"),
                            Price = 29,
                            ProductId = new Guid("1498f549-e790-4e9f-aa16-18c2292a2ee9")
                        });
                });

            modelBuilder.Entity("APIBasket.Entities.BasketLine", b =>
                {
                    b.HasOne("APIBasket.Entities.Basket", "Basket")
                        .WithMany("BasketLines")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("APIBasket.Entities.Basket", b =>
                {
                    b.Navigation("BasketLines");
                });
#pragma warning restore 612, 618
        }
    }
}
