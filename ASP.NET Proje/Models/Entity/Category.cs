﻿using ASP.NET_Proje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models
{
    public class Category: BaseEntity
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}