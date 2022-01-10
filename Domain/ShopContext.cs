using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
   public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed
            // modelBuilder.InsertCategory();
            // modelBuilder.InsertProduct();

            // add configuration
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());



        }
    }
    
}
