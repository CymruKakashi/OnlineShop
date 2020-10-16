using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class OnlineShopContext: DbContext
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options): base(options)
        {
        }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasOne(p => p.Currency)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CurrencyId);
                
                entity.HasOne(p => p.ProductType)
                    .WithMany(pt => pt.Products)
                    .HasForeignKey(p => p.ProductTypeId);
            });


            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
        }
    }
}
