using ASP.NET_Proje.Models.Entity;
using System.Collections.Generic;

namespace ASP.NET_Proje.Models.ViewModel
{
    public class DataViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categorys{ get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Campaign> Campaigns { get; set; }
        public IEnumerable<Branch> Branchs { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
    }
}