namespace StoreManagementSystem.DTOs.Inventories.Purchase
{
    public class PurchaseListDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
