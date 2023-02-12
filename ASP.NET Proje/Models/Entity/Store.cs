using ASP.NET_Proje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models
{
    public class Store: BaseEntity
    {
        public  string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }

    }
}
