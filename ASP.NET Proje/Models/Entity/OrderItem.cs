using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class OrderItem:BaseEntity
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductCount { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}