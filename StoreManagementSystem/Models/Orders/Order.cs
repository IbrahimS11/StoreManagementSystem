
namespace StoreManagementSystem.Models.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Note { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;



        public Guid CustomerPaymentId { get; set; }
        public CustomerPayment CustomerPayment { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
