using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DisplayName("İstifadəçi adı")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email ünvanı")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Şifrə")]
        public string Password { get; set; }
    }
}
