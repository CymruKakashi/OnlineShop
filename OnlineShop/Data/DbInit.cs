using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public static class DbInit
    {
        public static void Initialize(OnlineShopContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.ProductType.Any())
            {
                return;
            }

            var productType = new ProductType()
            {
                Description = "Fruit"
            };
            var currency = new Currency()
            {
                CurrencySymbol = "£",
                Name = "British Pound"
            };

            context.ProductType.Add(productType);
            context.Currency.Add(currency);

            context.SaveChanges();
        }
    }
}
