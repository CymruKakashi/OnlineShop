using OnlineShop.Data.Repositories;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Product>> GetProductsAsync()
        {
            IEnumerable<Product> results = await _repo.GetAllProductsAsync();
            return results.ToList();
        }
    }
}
