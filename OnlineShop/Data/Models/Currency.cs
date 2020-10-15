using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String CurrencySymbol { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
    }
}
