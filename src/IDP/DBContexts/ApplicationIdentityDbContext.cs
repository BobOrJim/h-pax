using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using IDP.Entities;

namespace IDP.DBContexts
{
    //public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly IHostEnvironment _environment;

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options, IHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_environment.IsDevelopment())
            {
                //Seeding AspNetRoles
                var RoleGuid_USER = Guid.Parse("{0110B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var RoleGuid_ADMIN = Guid.Parse("{0210B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var RoleGuid_ROOT = Guid.Parse("{0310B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var RoleGuid_SPARE1 = Guid.Parse("{0410B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var RoleGuid_SPARE2 = Guid.Parse("{0510B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var RoleGuid_Masters_Degree_In_Forestry = Guid.Parse("{0610B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                var Masters_Degree_In_Mining = Guid.Parse("{0710B1F9-8E0B-4A4F-A52E-DD20C3D4A539}");
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_USER, Name = "User", NormalizedName = "USER" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_ADMIN, Name = "Admin", NormalizedName = "ADMIN" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_ROOT, Name = "Root", NormalizedName = "ROOT" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_SPARE1, Name = "Spare1", NormalizedName = "SPARE1" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_SPARE2, Name = "Spare2", NormalizedName = "SPARE2" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = RoleGuid_Masters_Degree_In_Forestry, Name = "Masters_Degree_In_Forestry", NormalizedName = "Masters_Degree_In_Forestry" });
                modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = Masters_Degree_In_Mining, Name = "Masters_Degree_In_Forestry", NormalizedName = "Masters_Degree_In_Mining" });

                var hasher = new PasswordHasher<ApplicationRole>(); //a hasher to hash the password before seeding the user to the db

                //Seeding AspNetUsers
                var UserGuid_ADMIN = Guid.Parse("{20788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
                var UserGuid_ROOT = Guid.Parse("{2113179F-7837-473A-A4D5-A5571B43E6A6}");
                var UserGuid_USER = Guid.Parse("{223F3002-7E53-441E-8B76-F6280BE284AA}");
                string tmp = "ADMIN@ADMIN.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_ADMIN, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "admin") });
                tmp = "ROOT@ROOT.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_ROOT, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "root") });
                tmp = "USER@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_USER, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });

                //Seedings some more AspNetUsers
                var UserGuid_FRIEND1 = Guid.Parse("{2398F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND2 = Guid.Parse("{2498F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND3 = Guid.Parse("{2598F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND4 = Guid.Parse("{2698F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND5 = Guid.Parse("{2798F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND6 = Guid.Parse("{2898F549-E790-4E9F-AA16-18C2292A2EE9}");
                var UserGuid_FRIEND7 = Guid.Parse("{2998F549-E790-4E9F-AA16-18C2292A2EE9}");
                tmp = "FRIEND1@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND1, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND2@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND2, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND3@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND3, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND4@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND4, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND5@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND5, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND6@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND6, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });
                tmp = "FRIEND7@USER.com";
                modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = UserGuid_FRIEND7, UserName = tmp, NormalizedUserName = tmp, Email = tmp, NormalizedEmail = tmp, EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "user") });

                //Seeding the relation between user and role to AspNetUserRoles
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_ADMIN, UserId = UserGuid_ADMIN }); //Give admin admin role
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_ADMIN }); //Give admin user role
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_ROOT, UserId = UserGuid_ROOT }); //Give root root role
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_ROOT }); //Give root user role
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_USER }); //Give user user role
                //Everyone else get a user role
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND1 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND2 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND3 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND4 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND5 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND6 });
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = RoleGuid_USER, UserId = UserGuid_FRIEND7 });
            }
        }
    }
}
