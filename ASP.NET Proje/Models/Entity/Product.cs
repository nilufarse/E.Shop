using ASP.NET_Proje.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public int ? CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public string ? Description { get; set; }
        public string ? TotalCount { get; set; }
        public int ? GenderId { get; set; }
        public Gender Gender { get; set; }
        public int ? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int DeletedUserId { get; internal set; }
    }
}