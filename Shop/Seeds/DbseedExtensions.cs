using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Seeds
{
    public static class DbseedExtensions
    {
        public static void InsertProduct(this ModelBuilder builder)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, ProductName = "روان نویس", BrandName = "یونیبال", Price = 50000, Description = "---------", CategoryId = 1});
            products.Add(new Product() { Id = 2, ProductName = "خودکار", BrandName = "پنتر", Price = 10000, Description = "-----", CategoryId = 1 });
            products.Add(new Product() { Id = 3, ProductName = "خودکار", BrandName = "زبرا", Price = 20000, Description = "-----", CategoryId = 1 });
            products.Add(new Product() { Id = 4, ProductName = "جاروبرقی", BrandName = "سامسونگ", Price = 3000000, Description = "-----", CategoryId = 2 });
            products.Add(new Product() { Id = 5, ProductName = "یخچال", BrandName = "ال جی", Price = 9000000, Description = "-----", CategoryId = 2 });
            products.Add(new Product() { Id = 6, ProductName = "جاروبرقی", BrandName = "بوش", Price = 8000000, Description = "-----", CategoryId = 2 });

            builder.Entity<Product>().HasData(products);

        }
        public static void InsertCategory(this ModelBuilder builder)
        {
            IList<Category> Categories = new List<Category>();
            Categories.Add(new Category() { Id = 1, CategoryName = "لوازم تحریر " });
            Categories.Add(new Category() { Id = 2, CategoryName = "لوازم برقی خانگی"});
            Categories.Add(new Category() { Id = 3, CategoryName = "خواروبار" });
            Categories.Add(new Category() { Id = 4, CategoryName = "موادپروتیینی" });
            

            builder.Entity<Category>().HasData(Categories);

        }
    }
}
