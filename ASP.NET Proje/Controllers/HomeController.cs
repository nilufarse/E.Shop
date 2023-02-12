using ASP.NET_Proje.Data;
using ASP.NET_Proje.Models;
using ASP.NET_Proje.Models.Entity;
using ASP.NET_Proje.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(2000);
            cookieOptions.Path = "/";

            Response.Cookies.Append("aspcookie", $"{1}", cookieOptions);

            string cookieValueFromReq = Request.Cookies["aspcookie"];
            var value = Convert.ToInt32(cookieValueFromReq);

            var count = db.Baskets.Where(p => p.UserId == value).Count();




            ViewBag.Count = count;
            var vm = new DataViewModel();

            var category = db.Categorys.Where(c => c.DeletedDate == null).ToList();
            var product = db.Products.Where(c => c.DeletedDate == null).ToList();
            var gender = db.Genders.Where(g => g.DeletedDate == null).ToList();
            var campaigns = db.Campaigns.Where(g => g.DeletedDate == null && g.Discount != 0).ToList();
            vm.Genders = gender;
            vm.Categorys = category;
            vm.Products = product;
            vm.Campaigns = campaigns;
            return View(vm);
        }

        public IActionResult AddToCart(int? id)
        {

            var basket = new Basket();
            string cookieValueFromReq = Request.Cookies["aspcookie"];
            var value = Convert.ToInt32(cookieValueFromReq);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);


            var basketrow = db.Baskets.FirstOrDefault(p => p.ProductId == id && p.UserId == userId);

            if (basketrow != null)
            {
                return Json(new
                {
                    error = true,
                    msg = "Siz bu product-i elave etmisiniz"
                });
            }
            else
            {
                basket.ProductId = (int)id;
                basket.UserId = userId;
                db.Baskets.Add(basket);
                db.SaveChanges();



                return Json(new
                {
                    error = false,
                    msg = "Siz bu product-i elave etdiniz"
                });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
