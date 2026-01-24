using StoreManagementSystem.Identity;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Account
{
    public class RegisterByAdminDto
    {
        [Required(ErrorMessage ="ادخل الاسم")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "ادخل رقم الهاتف")]
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = " يجب ان يبدا ب (010|011|012|015) ومكون من 11 رقم")]
        public string Phone { get; set; } = null!;


        [Required(ErrorMessage ="اختر البلد")]
        public int CityId { get; set; }


        [Required(ErrorMessage = "اختر الشارع")]
        public int StreetId { get; set; }

        public string role { get; set; } = "customer";

        public string? AddressDetails { get; set; }
    }
}
