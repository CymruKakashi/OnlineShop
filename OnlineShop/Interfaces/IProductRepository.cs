using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync(string[] includes = null);
        Task<Product> GetById(int productId);
        Task SaveChangesAsync();
        void DeleteAllProducts();
        Task AddProducts(List<Product> dbProducts);
    }
}
