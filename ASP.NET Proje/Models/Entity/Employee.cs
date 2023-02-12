using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Entity
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
