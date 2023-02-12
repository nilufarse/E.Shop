using ASP.NET_Proje.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class Basket : BaseEntity
    {
        public int? UserId { get; set; }
        public AppUser User { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductCount { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}