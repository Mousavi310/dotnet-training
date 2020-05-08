using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftDeleteSample
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This will make sure we have unique product names
            modelBuilder
                .Entity<Product>()
                .HasIndex(p => p.Name)
                //This make index filtered
                .HasFilter("IsDeleted = 0")
                .IsUnique();

            //This will exclude products with IsDeleted=1 when querying Products using EF
            modelBuilder
                .Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
