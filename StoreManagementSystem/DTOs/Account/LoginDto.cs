using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Account
{
    public class LoginDto
    {

        [Required(ErrorMessage = "ادخل رقم الهاتف")]
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = " يجب ان يبدا ب (010|011|012|015) ومكون من 11 رقم")]
        public string Phone { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
        
    }
}
