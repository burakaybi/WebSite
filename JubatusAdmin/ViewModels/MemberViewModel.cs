using JubatusAdmin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JubatusAdmin.ViewModels
{
    public class MemberViewModel
    {
        [Display(Name = "E-mail")]
        [RegularExpression("^[_A-Za-z'`+-.]+([_A-Za-z0-9'+-.]+)*@([A-Za-z0-9-])+(\\.[A-Za-z0-9]+)*(\\.([A-Za-z]*){3,})$", ErrorMessage = "Geçerli bir E-mail adresi giriniz...")]
        [Required(ErrorMessage = "E-mail adresi boş geçilemez...")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir E-mail adresi giriniz...")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int MemberId { get; set; }
        public int MemberRoleId { get; set; }
        public IEnumerable<MemberRole> Roles { get; set; }
    }

    public class MemberDetailViewModel
    {
        public List<MemberDetail> MemberList { get; set; }
        public MemberDetail UpdatedMember { get; set; }
        public IEnumerable<MemberRole> Roles { get; set; }
    }

}
