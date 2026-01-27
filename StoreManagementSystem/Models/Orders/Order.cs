
namespace StoreManagementSystem.Models.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; } = null!;
        public OrderStatus Status { get;private set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;



        public Guid InitialPaymentId { get; set; }
        public CustomerPayment InitailPayment { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void MakeOrderStatusCompleted()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException(
                    $"Order cannot move from {Status} to Completed");

            Status = OrderStatus.Completed;
        }


    }

   

        
      

}
