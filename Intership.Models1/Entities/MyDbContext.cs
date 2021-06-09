using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Entities.Configuration;

namespace Entities.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new RepairsConfiguration());
            modelBuilder.ApplyConfiguration(new StatusesConfiguration());
            modelBuilder.ApplyConfiguration(new RepairsInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ReplacedPartsConfiguration());
            
            modelBuilder.Entity<RepairInfo>()
                .HasOne(r => r.Repair)
                .WithMany(r => r.RepairsInfo)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ReplacedPart>()
                .HasOne(r => r.Repair)
                .WithMany(r => r.ReplacedParts)
                .OnDelete(DeleteBehavior.NoAction);
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<ReplacedPart> ReplacedParts { get; set; }
        public DbSet<RepairInfo> RepairsInfo { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
