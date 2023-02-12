using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ASP.NET_Proje.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsSeller { get; set; }
        public int UserType { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
    }
}