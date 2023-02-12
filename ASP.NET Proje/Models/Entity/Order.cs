using ASP.NET_Proje.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class Order:BaseEntity
    {
        public int? UserId { get; set; } 
        public AppUser User { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}