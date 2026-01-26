using StoreManagementSystem.DTOs.Inventories.PurchaseItem;

namespace StoreManagementSystem.DTOs.Inventories.Purchase
{
    public class PurchaseReadDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string? Note { get; set; } = null!;

        public Guid SupplierId { get; set; }


        public Guid SupplierPaymentId { get; set; }

        public ICollection<PurchaseItemReadDto> PurchaseItems { get; set; } = new List<PurchaseItemReadDto>();

    }
}
