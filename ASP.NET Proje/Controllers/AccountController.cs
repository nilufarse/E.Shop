using ASP.NET_Proje.Models.FormModel;
using ASP.NET_Proje.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly SignInManager<AppUser> signInManager;
        readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Login(UserFormModel model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await userManager.FindByNameAsync(model.Username);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                    goto showSameView;
                }
                var result = await signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

                if (result.Succeeded)
                {

                    string redirect = Request.Query["returnUrl"];
                    if (string.IsNullOrWhiteSpace(redirect))
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                    goto showSameView;
                }
            }
        showSameView:
            return View(model);
        }
        public IActionResult Register()
        {
            ModelState.Clear();
            return View();
        }
      
        [HttpPost]
        async public Task<IActionResult> Register(RegisterFormModel model)
        {
        
                var appUser = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = await userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        ViewBag.Error = $"{error.Description}";
                    }
                return View(model);
            }
          
          
        }
        async public Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
