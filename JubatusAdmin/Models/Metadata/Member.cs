using System.ComponentModel.DataAnnotations;
namespace JubatusAdmin.Models
{
    [MetadataType(typeof(MemberDetailMetadata))]
    public partial class MemberDetail
    {
    }

    public class MemberDetailMetadata
    {
        [Display(Name = "E-mail")]
        [RegularExpression("^[_A-Za-z'`+-.]+([_A-Za-z0-9'+-.]+)*@([A-Za-z0-9-])+(\\.[A-Za-z0-9]+)*(\\.([A-Za-z]*){3,})$", ErrorMessage = "Geçerli bir E-mail adresi giriniz...")]
        [Required(ErrorMessage = "E-mail adresi boş geçilemez...")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir E-mail adresi giriniz...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Rol boş geçilemez...")]
        public int MemberRoleId { get; set; }

    }
}
