using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Proje.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role adı")]
        [Required(ErrorMessage = "Role adı lazımdır.")]
        public string Name { get; set; }
        
    }
}
