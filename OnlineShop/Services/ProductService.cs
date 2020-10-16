using OnlineShop.Constants;
using OnlineShop.Data.Repositories;
using OnlineShop.DataTransferModels;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repo; 
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> ExportProducts()
        {
            List<Product> products = await GetProductsAsync();
            var sep = Csv.Seperator;
            var csv = new StringBuilder();
            csv.Append($"{Csv.Fruit}{sep}{Csv.Price}{sep}{Csv.Quantity}{sep}{Csv.UpdatedDate}{Environment.NewLine}");
            foreach (var product in products) 
            {
                csv.Append($"{product.Name}{sep}{Math.Round(product.Price,2)}{sep}{product.Quantity}{sep}{product.UpdatedDate.ToString(Global.DateFormat)}{Environment.NewLine}");
            }
            return csv.ToString();

        }

        public async Task<List<Product>> GetProductsAsync()
        {
            string[] includes = new string[] { EntityConstants.Currency, EntityConstants.ProductType };
            IEnumerable<Product> results = await _repo.GetAllProductsAsync(includes);
            return results.ToList();
        }

        public async Task SetProductPrice(ProductPriceUpdate priceUpdate)
        {
            Product product = await _repo.GetById(priceUpdate.ProductId);
            product.Price = priceUpdate.ProductPrice;
            product.UpdatedDate = DateTime.Now;
            await _repo.SaveChangesAsync();
        }

        public async Task UploadProducts(List<ProductUpload> products)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            _repo.DeleteAllProducts();
            List<Product> dbProducts = new List<Product>();
            foreach(ProductUpload product in products) 
            {
                var dbProduct = new Product()
                {
                   Name = product.Name,
                   Price = product.Price,
                   Quantity = product.Quantity,
                   UpdatedDate = DateTime.ParseExact(product.UpdatedDate,Global.DateFormat,provider),
                   CurrencyId = 1,
                   ProductTypeId = 1
                };
                dbProducts.Add(dbProduct);
            }
            if (dbProducts.Count > 0) {
                await _repo.AddProducts(dbProducts);
            }
        }
    }
}
