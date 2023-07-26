using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDemo.Models;

namespace StoreDemo.Data
{
    public class StoreDemoContext : DbContext
    {
        public StoreDemoContext (DbContextOptions<StoreDemoContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }


    }
}
