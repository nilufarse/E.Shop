using ASP.NET_Proje.Models.Entity;
using ASP.NET_Proje.Models.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Proje.Areas.Admin.ViewModel
{
    public class UserManagmentViewModel
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int UserType { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
