using Microsoft.EntityFrameworkCore;
using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.DbContexts
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database = ProductCatalog;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            //Adding some example properties just for fun.
            modelBuilder.Entity<Product>().HasKey(p => new { p.ProductId });
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("Product name");

            //Seeding
            var ReservoirDogsGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var TrueRomanceGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var PulpFictionGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var NaturalBornKillersGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            var FromDuskTillDawnGuid = Guid.Parse("{1098F549-E790-4E9F-AA16-18C2292A2EE9}");

            var JackieBrownGuid = Guid.Parse("{1198F549-E790-4E9F-AA16-18C2292A2EE9}");
            var InglouriousBasterdsGuid = Guid.Parse("{1298F549-E790-4E9F-AA16-18C2292A2EE9}");
            var DjangoUnchainedGuid = Guid.Parse("{1398F549-E790-4E9F-AA16-18C2292A2EE9}");
            var TheHatefulEightGuid = Guid.Parse("{1498F549-E790-4E9F-AA16-18C2292A2EE9}");
            var OnceUponaTimeInHollywoodGuid = Guid.Parse("{1598F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = ReservoirDogsGuid, Name = "Reservoir Dogs", Price = 21, ImageUrl = "SomeURL", Description = "Movie 1" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = TrueRomanceGuid, Name = "True Romance", Price = 22, ImageUrl = "SomeURL", Description = "Movie 2" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = PulpFictionGuid, Name = "Pulp Fiction", Price = 23, ImageUrl = "SomeURL", Description = "Movie 3" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = NaturalBornKillersGuid, Name = "Natural BornKillers", Price = 24, ImageUrl = "SomeURL", Description = "Movie 4" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = FromDuskTillDawnGuid, Name = "From Dusk Till Dawn", Price = 25, ImageUrl = "SomeURL", Description = "Movie 5" });

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = JackieBrownGuid, Name = "Jackie Brown", Price = 26, ImageUrl = "SomeURL", Description = "Movie 6" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = InglouriousBasterdsGuid, Name = "Inglourious Basterds", Price = 27, ImageUrl = "SomeURL", Description = "Movie 7" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = DjangoUnchainedGuid, Name = "Django Unchained", Price = 28, ImageUrl = "SomeURL", Description = "Movie 8" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = TheHatefulEightGuid, Name = "The Hateful Eight", Price = 29, ImageUrl = "SomeURL", Description = "Movie 9" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = OnceUponaTimeInHollywoodGuid, Name = "Once Upon a Time In Hollywood", Price = 30, ImageUrl = "SomeURL", Description = "Movie 10" });

        }
    }
}
