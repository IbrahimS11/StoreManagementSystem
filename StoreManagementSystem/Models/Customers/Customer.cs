using StoreManagementSystem.Models.Orders;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;


        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public CustomerAddress Address { get; set; } = null!;

        
        public ICollection<CustomerPayment> Payments { get; set; } = new List<CustomerPayment>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
