namespace StoreManagementSystem.Models.Inventory
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Note { get; set; } = null!;
    }
}
