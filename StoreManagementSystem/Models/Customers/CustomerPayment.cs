using StoreManagementSystem.Models.Orders;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models.Customers
{
    public class CustomerPayment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = null!;
        public decimal BalanceAfter { get; set; }



        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;



        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }

    }
}
