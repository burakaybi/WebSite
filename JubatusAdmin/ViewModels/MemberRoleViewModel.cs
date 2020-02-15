using JubatusAdmin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JubatusAdmin.ViewModels
{
    public class MemberRoleViewModel
    {
        public List<MemberRole> MemberRoleList { get; set; }
        [Required(ErrorMessage = "Rol boş geçilemez...")]
        public MemberRole MemberRole { get; set; }
        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Rol boş geçilemez...")]
        public string MemberRoleDesc { get; set; }
    }
}