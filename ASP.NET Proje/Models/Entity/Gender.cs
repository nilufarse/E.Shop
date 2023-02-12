using System.Collections;
using System.Collections.Generic;

namespace ASP.NET_Proje.Models.Entity
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
