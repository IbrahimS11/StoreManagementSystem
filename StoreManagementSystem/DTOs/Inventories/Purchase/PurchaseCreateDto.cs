using StoreManagementSystem.DTOs.Inventories.PurchaseItem;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Inventories.Purchase
{
    public class PurchaseCreateDto
    {
        public Guid SupplierId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; }

        [Required]
        public IEnumerable<PurchaseItemCreateDto> PurchaseItems { get; set; } = new List<PurchaseItemCreateDto>();
    }
}
