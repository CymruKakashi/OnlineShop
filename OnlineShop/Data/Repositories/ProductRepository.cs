using OnlineShop.Interfaces;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Product>> GetAllProductsAsync() 
        {
            return await GetAllAsync<Product>();
        }
    }
}
