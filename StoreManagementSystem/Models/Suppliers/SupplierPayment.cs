namespace StoreManagementSystem.Models.Suppliers
{
    public class SupplierPayment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = null!;
        public decimal BalanceAfter { get; set; }
    }
}
