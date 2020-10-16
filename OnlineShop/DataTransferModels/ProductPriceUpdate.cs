using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DataTransferModels
{
    public class ProductPriceUpdate
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
