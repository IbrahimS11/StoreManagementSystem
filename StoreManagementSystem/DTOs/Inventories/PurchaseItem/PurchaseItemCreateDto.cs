using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Inventories.PurchaseItem
{
    public class PurchaseItemCreateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "[ادخل رقم صالح بين [1-1000")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "السعر الذي ادخلته غير صحيح")]
        public decimal UnitPrice { get; set; }
    }
}
