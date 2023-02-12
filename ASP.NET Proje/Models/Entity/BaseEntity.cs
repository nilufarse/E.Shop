using ASP.NET_Proje.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class BaseEntity
    {
            public int Id { get; set; }
            public DateTime? CreatedDate { get; set; } = DateTime.UtcNow.AddHours(24);

            public DateTime? UpdatedDate { get; set; }

            public DateTime? DeletedDate { get; set; }

    }
}
