using ASP.NET_Proje.Data;
using ASP.NET_Proje.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ASP.NET_Proje.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class GenderController : Controller
    {
        readonly AppDbContext db;

        public GenderController(AppDbContext db)
        {
            this.db = db;
          
        }
        public IActionResult Index()
        {
            var genders = db.Genders.Where(g => g.DeletedDate == null).ToList();
            return View(genders);
        }

        public IActionResult GenderAdd()
        {
  
            return View();
        }

        [HttpPost]
        public IActionResult GenderAdd(Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult GenderDelete(int? id)
        {
            var gender = db.Genders.Find(id);

            return View(gender);
        }

        [HttpPost]
        public IActionResult GenderDelete(Gender gender)
        {
            gender.DeletedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Update(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
