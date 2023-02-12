using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? Gender { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
    }
}
