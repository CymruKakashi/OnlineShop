using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
    }
}
