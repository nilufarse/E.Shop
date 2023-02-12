using ASP.NET_Proje.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace ASP.NET_Proje.Controllers
{
    public class BasketController : Controller
    {
        readonly AppDbContext db;
        public BasketController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            
            var value = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); ;
            ViewData["User"] = value;


            var count = db.Baskets.Where(p => p.UserId == value).Count();

            ViewBag.Count = count;
            return View();
        }
    }
}
