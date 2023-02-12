﻿using System.Collections;
using System.Collections.Generic;

namespace ASP.NET_Proje.Models.Entity
{
    public class Campaign:BaseEntity
    {
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
