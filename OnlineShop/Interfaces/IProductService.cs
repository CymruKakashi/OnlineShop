﻿using OnlineShop.DataTransferModels;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        Task SetProductPrice(ProductPriceUpdate priceUpdate);
        Task UploadProducts(List<ProductUpload> products);
        Task<string> ExportProducts();
    }
}
