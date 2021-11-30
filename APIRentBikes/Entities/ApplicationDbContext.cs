using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BikeConfiguration());
            modelBuilder.ApplyConfiguration(new RentalTypeConfiguration());

            modelBuilder
                .Entity<Order>()
                .HasIndex(e => e.Id_RentalType)
                .IsUnique(false);
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBike> OrderBikes { get; set; }
        public DbSet<RentalType> RentalTypes { get; set; }
    }
}
