using ASP.NET_Proje.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models
{
    public class Branch : BaseEntity
    {
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}