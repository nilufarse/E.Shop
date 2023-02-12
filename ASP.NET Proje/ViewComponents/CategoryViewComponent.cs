using ASP.NET_Proje.Data;
using ASP.NET_Proje.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        readonly AppDbContext db;
        public CategoryViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new DataViewModel();
            var gender = db.Genders.Where(p => p.DeletedDate == null).ToList();
            var category = db.Categorys.Where(p => p.DeletedDate == null).ToList();
            vm.Genders = gender;
            vm.Categorys = category;
            return Task.FromResult<IViewComponentResult>(View(vm));
        }
    }
}
