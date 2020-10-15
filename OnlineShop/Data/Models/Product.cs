using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [Column(TypeName = "decimal(19,4)")]
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductTypeId { get; set; }
        public int CurrencyId { get; set; }
        [JsonIgnore]
        public virtual ProductType ProductType { get; set; }
        [JsonIgnore]
        public virtual Currency Currency { get; set; }
    }   
}
