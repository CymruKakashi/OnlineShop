using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public abstract class BaseRepository
    {
        private OnlineShopContext _context;
        public BaseRepository(OnlineShopContext context)
        {
            _context = context;
        }

        protected async Task<IEnumerable<T>> GetAllAsync<T>(string[] includes = null) where T: class 
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
                query = includes.Aggregate(query, (query, include) => query.Include(include));
            return await query.ToListAsync();
        }

    }
}
