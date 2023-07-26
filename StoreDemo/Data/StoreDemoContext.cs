using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StoreDemo.Models;

namespace StoreDemo.Data
{
    public class StoreDemoContext : DbContext
    {
        public StoreDemoContext (DbContextOptions<StoreDemoContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: Category to Product
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
        .HasOne(p => p.size) // Product has one Size
        .WithOne(s => s.Product) // Size has one Product
        .HasForeignKey<Size>(s => s.ProductId);


            modelBuilder.Entity<Product>()
        .HasMany(p => p.colors)
        .WithMany(c => c.Products);
  

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }


    }
}
