
using ASP.NET_Proje.Data;
using ASP.NET_Proje.Models;
using ASP.NET_Proje.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        readonly AppDbContext db;
        public ProductViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public Task<IViewComponentResult> InvokeAsync(int? gender, int? category, int? campaign)
        {
            var vm = new DataViewModel();
            var campaigns = db.Campaigns.Where(p => p.DeletedDate == null).ToList();
            vm.Products = (List<Product>) null;
            vm.Campaigns = campaigns;
            
            if(gender == null)
            {
                if(category == null)
                {
                    if(campaign != null)
                    {
                        vm.Products = db.Products.Where(p => p.DeletedDate == null && p.CampaignId == campaign).ToList();
                    }
                    else
                    {
                        vm.Products = db.Products.Where(p => p.DeletedDate == null).ToList();
                    }
                }
                else
                {
                    vm.Products = db.Products.Where(p => p.DeletedDate == null && p.CategoryId == category).ToList();
                }
            }
            else
                {
                vm.Products = db.Products.Where(p => p.DeletedDate == null && p.GenderId == gender).ToList();
                }
            return Task.FromResult<IViewComponentResult>(View(vm));
        }
    }
}
