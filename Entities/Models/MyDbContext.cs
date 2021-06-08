using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Entities.Configuration;

namespace Entities.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() //for now it will be empty
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


            modelBuilder.Entity<RepairInfo>()
                .HasOne(r => r.Repair)
                .WithMany(r => r.RepairsInfo)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<RepairInfo>()//if statuses was deleted, repairs info need to leave alive in system;
                .HasOne(r => r.Status)
                .WithMany(s => s.RepairsInfo)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()//if we wanna delete the product we shouldn`t delete orders by this product; 50\50
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.SetNull);
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
