using ASP.NET_Proje.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Controllers
{
    [AllowAnonymous]
    public class Main_HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public Main_HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SellerRequest()
        {
             var user = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var userInDb = _appDbContext.Users.FirstOrDefault(u => u.Id == user);

            _appDbContext.Users.Update(userInDb);
            _appDbContext.SaveChanges();
            ViewBag.msg = "Your Request has been send successfuly";
            return RedirectToAction("index");
            
        }
    }
}
