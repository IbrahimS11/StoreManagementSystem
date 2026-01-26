namespace StoreManagementSystem.DTOs.Inventories.PurchaseItem
{
    public class PurchaseItemReadDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Guid PurchaseId { get; set; }

        public int ProductId { get; set; }

    }
}
