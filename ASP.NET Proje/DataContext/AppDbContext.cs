using ASP.NET_Proje.Models;
using ASP.NET_Proje.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Proje.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Store> Stores { get; set; }


        #region Idendity
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppUserClaim> UserClaims { get; set; }
        public DbSet<AppRoleClaim> RoleClaims { get; set; }
        public DbSet<AppUserToken> UserTokes { get; set; }
        public DbSet<AppUserLogin> UserLogins { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity
            modelBuilder.Entity<AppUser>(e =>
            {
                e.ToTable("Users", "Identity");
            });

            modelBuilder.Entity<AppUserRole>(e =>
            {
                e.ToTable("UserRoles", "Identity");
            });

            modelBuilder.Entity<AppUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Identity");

            });

            modelBuilder.Entity<AppRole>(e =>
            {
                e.ToTable("Roles", "Identity");
            });

            modelBuilder.Entity<AppRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Identity");
            });

            modelBuilder.Entity<AppUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Identity");
            });

            modelBuilder.Entity<AppUserToken>(e =>
            {
                e.ToTable("UserTokens", "Identity");
            });
            #endregion
        }
    }
}
