using APIBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBasket.DbContexts
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database = APIBasket;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().HasKey(b => new { b.BasketId });
            modelBuilder.Entity<Basket>().Property(b => b.BasketId).IsRequired();
            modelBuilder.Entity<BasketLine>().HasKey(bl => new { bl.BasketLineId });
            modelBuilder.Entity<BasketLine>().Property(bl => bl.BasketLineId).IsRequired();

            modelBuilder.Entity<Basket>()
                .HasMany(b => b.BasketLines)
                .WithOne(bl => bl.Basket)
                .HasForeignKey(t => t.BasketId); //FK in BasketLines


            //Seeding:
            //Baskets sent to Order microservice

            //user ADMIN basket 1
            Guid UserGuid_ADMIN = Guid.Parse("{20788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            Guid Basket1Guid_ADMIN = Guid.Parse("{B650B275-5CE8-4FCC-AFC4-56005109E2E5}");
            Guid BasketLine1Guid_ADMIN = Guid.Parse("{A94D70C5-1217-463B-B318-93679084BADA}");
            Guid ReservoirDogsGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            Guid BasketLine2Guid_ADMIN = Guid.Parse("{B94D70C5-1217-463B-B318-93679084BADA}");
            Guid TrueRomanceGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            Guid BasketLine3Guid_ADMIN = Guid.Parse("{C94D70C5-1217-463B-B318-93679084BADA}");
            Guid PulpFictionGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            modelBuilder.Entity<Basket>().HasData(new Basket { BasketId = Basket1Guid_ADMIN, UserId = UserGuid_ADMIN, BasketLines = new List<BasketLine>(), CouponId = null });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine1Guid_ADMIN, BasketId = Basket1Guid_ADMIN, ProductId = ReservoirDogsGuid, Price = 21, Amount = 1 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine2Guid_ADMIN, BasketId = Basket1Guid_ADMIN, ProductId = TrueRomanceGuid, Price = 22, Amount = 2 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine3Guid_ADMIN, BasketId = Basket1Guid_ADMIN, ProductId = PulpFictionGuid, Price = 23, Amount = 1 });

            //user ADMIN basket 2
            Guid ADMINGuid_Basket2 = Guid.Parse("{C650B275-5CE8-4FCC-AFC4-56005109E2E5}");
            Guid Basket2Guid_ADMIN = Guid.Parse("{8B19D011-3710-4B87-9B5F-2A1E6EE1404B}");
            Guid NaturalBornKillersGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine4Guid_ADMIN = Guid.Parse("{972B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            Guid FromDuskTillDawnGuid = Guid.Parse("{1098F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine5Guid_ADMIN = Guid.Parse("{A72B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            Guid JackieBrownGuid = Guid.Parse("{1198F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine6Guid_ADMIN = Guid.Parse("{B72B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            modelBuilder.Entity<Basket>().HasData(new Basket { BasketId = Basket2Guid_ADMIN, UserId = UserGuid_ADMIN, BasketLines = new List<BasketLine>(), CouponId = null });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine4Guid_ADMIN, BasketId = Basket2Guid_ADMIN, ProductId = NaturalBornKillersGuid, Price = 24, Amount = 3 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine5Guid_ADMIN, BasketId = Basket2Guid_ADMIN, ProductId = FromDuskTillDawnGuid, Price = 25, Amount = 1 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine6Guid_ADMIN, BasketId = Basket2Guid_ADMIN, ProductId = JackieBrownGuid, Price = 26, Amount = 1 });

            //user FRIEND1 basket 1
            Guid UserGuid_FRIEND1 = Guid.Parse("{2398F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid Basket1Guid_FRIEND1 = Guid.Parse("{D650B275-5CE8-4FCC-AFC4-56005109E2E5}");
            Guid InglouriousBasterdsGuid = Guid.Parse("{1298F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine7Guid_ADMIN = Guid.Parse("{C72B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            Guid DjangoUnchainedGuid = Guid.Parse("{1398F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine8Guid_ADMIN = Guid.Parse("{D72B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            Guid TheHatefulEightGuid = Guid.Parse("{1498F549-E790-4E9F-AA16-18C2292A2EE9}");
            Guid BasketLine9Guid_ADMIN = Guid.Parse("{E72B1DE4-FD41-4D6D-8D7A-CF80219E60D7}");
            modelBuilder.Entity<Basket>().HasData(new Basket { BasketId = Basket1Guid_FRIEND1, UserId = UserGuid_FRIEND1, BasketLines = new List<BasketLine>(), CouponId = null });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine7Guid_ADMIN, BasketId = Basket1Guid_FRIEND1, ProductId = InglouriousBasterdsGuid, Price = 27, Amount = 1 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine8Guid_ADMIN, BasketId = Basket1Guid_FRIEND1, ProductId = DjangoUnchainedGuid, Price = 28, Amount = 1 });
            modelBuilder.Entity<BasketLine>().HasData(new BasketLine { BasketLineId = BasketLine9Guid_ADMIN, BasketId = Basket1Guid_FRIEND1, ProductId = TheHatefulEightGuid, Price = 29, Amount = 1 });

        }
    }
}
