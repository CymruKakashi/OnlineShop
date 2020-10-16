using Microsoft.EntityFrameworkCore;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private OnlineShopContext _context;
        public ProductRepository(OnlineShopContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string[] includes = null) 
        {
            return await GetAllAsync<Product>(includes);
        }

        public async Task<Product> GetById(int productId)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public void DeleteAllProducts() 
        {
            this._context.Database.ExecuteSqlRaw("TRUNCATE TABLE Product");
        }

        public async Task AddProducts(List<Product> dbProducts)
        {
            this._context.Product.AddRange(dbProducts);
            await this._context.SaveChangesAsync();
        }
    }
}
