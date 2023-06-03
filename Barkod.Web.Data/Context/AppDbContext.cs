using BarkodWeb.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BarkodWeb.Data.Context
{
    
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       



        protected override void OnModelCreating(ModelBuilder builder)
        {
            //    base.OnModelCreating(modelBuilder);

            //    // Global turn off delete behaviour on foreign keys
            //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //    {
            //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //    }

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


           







        }

        public DbSet<LowerGroup> LowerGroups { get; set; }
        public DbSet<MainGroup> MainGroups { get; set; }
        public DbSet<Repair>Repairs { get; set; }
        public DbSet<Report>Reports { get; set; }
        public DbSet<Sale>sales { get; set; }
        public DbSet<Shop>Shops { get; set; }
        public DbSet<Stock>Stocks { get; set; }
        
    }
    
}
