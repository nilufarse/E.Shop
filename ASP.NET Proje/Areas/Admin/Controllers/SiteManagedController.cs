using ASP.NET_Proje.Data;
using ASP.NET_Proje.Models;
using ASP.NET_Proje.Models.Entity;
using ASP.NET_Proje.Models.ViewModel;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace ASP.NET_Proje.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]

    public class SiteManagedController : Controller
    {
        readonly AppDbContext db;
        IHostingEnvironment env;

        public SiteManagedController(AppDbContext db, IHostingEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        

        public IActionResult Index()
        {
            var vm = new DataViewModel();
            var categorys = db.Categorys.Where(c => c.DeletedDate == null).ToList();
            var products = db.Products.Where(p => p.DeletedDate == null).ToList();
            var campaign = db.Campaigns.Where(p => p.DeletedDate == null).ToList();
            vm.Categorys = categorys;
            vm.Products = products;
            vm.Campaigns = campaign;
            return View(vm);
        }
 
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Add(category);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }
        public IActionResult CategoryUpdate(int? id)
        {
            var category = db.Categorys.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedDate = DateTime.UtcNow;
                db.Categorys.Update(category);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }
        public IActionResult CategoryDetail(int? id)
        {
            var category = db.Categorys.Find(id);
            return View(category);
        }
        public IActionResult CategoryDelete(int? id)
        {
            var category = db.Categorys.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryDelete(Category category)
        {
            if (ModelState.IsValid)
            {
                category.DeletedDate = DateTime.Now;
                db.Categorys.Update(category);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }
        public IActionResult ProductAdd()
        {
            ViewBag.Category = new SelectList(db.Categorys.Where(g => g.DeletedDate == null), "Id", "Name");
            ViewBag.Campaign = new SelectList(db.Campaigns.Where(g => g.DeletedDate == null), "Id", "Name");
            ViewBag.Gender = new SelectList(db.Genders.Where(g=>g.DeletedDate == null), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(IFormFile file, Product product)
        {
            var filePath = "";
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\assets\img\";
                var uploadPath = env.WebRootPath + imagePath;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);

                }
                var unicFileName = Guid.NewGuid().ToString();

                var fileName = Path.GetFileName(unicFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;
                filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                product.ImagePath = fileName;
                product.CategoryId= Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("index");
                

            }

            return View(product);
       

        }
        public IActionResult ProductUpdate(int? id)
        {
            ViewBag.Category = new SelectList(db.Categorys, "Id", "Name");
            ViewBag.Gender = new SelectList(db.Genders.Where(g => g.DeletedDate == null), "Id", "Name");
            ViewBag.Campaign = new SelectList(db.Campaigns.Where(g => g.DeletedDate == null), "Id", "Name");
            var product = db.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult ProductUpdate(IFormFile file, Product product)
        {

            var filePath = "";

            if (file != null && file.Length > 0)
            {
                var imagePath = @"\assets\img\";
                var uploadPath = env.WebRootPath + imagePath;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);

                }
                var unicFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(unicFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;
                filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                product.ImagePath = fileName;
            }

            product.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {

                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(product);
        }
        public IActionResult ProductDelete(int? id)
        {
            ViewBag.Category = new SelectList(db.Categorys, "Id", "Name");

            var product = db.Products.Find(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult ProductDelete(Product product)
        {
            product.DeletedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(product);
        }

        public IActionResult CampaignAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CampaignAdd(Campaign campaign)
        {

            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(campaign);
        }

        public IActionResult CampaignUpdate(int id)
        {
            var campaign = db.Campaigns.Find(id);
            return View(campaign);
        }

        [HttpPost]
        public IActionResult CampaignUpdate(Campaign campaign)
        {
            campaign.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {

                db.Campaigns.Update(campaign);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(campaign);
        }

        public IActionResult CampaignDetail(int id)
        {
            var campaign = db.Campaigns.Find(id);
            return View(campaign);
        }

        [HttpPost]
        public IActionResult CampaignDetail(Campaign campaign)
        {
            campaign.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Campaigns.Update(campaign);
                db.SaveChanges();
                return RedirectToAction("index");
            }


            return View(campaign);
        }


        public IActionResult CampaignDelete(int id)
        {

            var campaign = db.Campaigns.Find(id);
            return View(campaign);
        }

        [HttpPost]
        public IActionResult CampaignDelete(Campaign campaign)
        {

            campaign.DeletedDate = DateTime.Now;
            if (ModelState.IsValid)
            {

                db.Campaigns.Update(campaign);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(campaign);
        }
    }
}
