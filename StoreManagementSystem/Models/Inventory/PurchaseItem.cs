namespace StoreManagementSystem.Models.Inventory
{
    public class PurchaseItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
