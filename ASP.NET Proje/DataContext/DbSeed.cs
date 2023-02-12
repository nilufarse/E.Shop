using ASP.NET_Proje.Data;
using Microsoft.AspNetCore.Identity;
using ASP.NET_Proje.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Proje.Models;

namespace ASP.NET_Proje.DataContext
{
    public static class DbSeed
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            const string adminEmail = "nilufarse@code.edu.az";
            const string adminPassword = "Nilufer2022100%";
            const string superAdminRoleName = "SuperAdmin";

            using (var scope = app.ApplicationServices.CreateScope())
            {

                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                db.Database.Migrate();

                var role = roleManager.FindByNameAsync(superAdminRoleName).Result;
                if (role == null)
                {
                    role = new AppRole
                    {
                        Name = superAdminRoleName
                    };

                    roleManager.CreateAsync(role).Wait();
                }


                var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var adminUser = userManeger.FindByEmailAsync(adminEmail).Result;

                if (adminUser == null)
                {
                    adminUser = new AppUser
                    {
                    Email = adminEmail,
                        UserName = adminEmail,
                        EmailConfirmed = true
                    };

                var userResult = userManeger.CreateAsync(adminUser, adminPassword).Result;

                if (userResult.Succeeded)
                {
                    userManeger.AddToRoleAsync(adminUser, superAdminRoleName).Wait();
                }

            }


            if (!db.Stores.Any())
            {
                db.Stores.Add(new Store()
                {
                    Name = "Center",
                    Description = "Example"
                });
                db.SaveChanges();
            }
        }


            return app;
        }
    }
}
