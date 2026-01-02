namespace StoreManagementSystem.Models.Customers
{
    public class CustomerPayment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = null!;
        public decimal BalanceAfter { get; set; }
    }
}
