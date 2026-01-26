using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Inventories.Purchase
{
    public class PurchaseCompleteDto
    {
        [Required]
        public Guid PurchaseId { get; set; }
        [Required]
        [Range(0, int.MaxValue,ErrorMessage ="ادخل رقم صحيح")]
        public decimal  AmountPaid{ get; set; }
        public string? Note {  get; set; }
    }
}
