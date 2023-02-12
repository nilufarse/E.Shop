using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASP.NET_Proje.Areas.Admin.ViewModel
{
    public class UserRoleViewModel
    {
        public int userId { get; set; }
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string employeeFullName { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
