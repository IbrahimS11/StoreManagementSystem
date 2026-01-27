using StoreManagementSystem.Identity;
using StoreManagementSystem.Models.Orders;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;


        public CustomerAddress Address { get; set; } = null!;

        
        public ICollection<CustomerPayment> Payments { get; set; } = new List<CustomerPayment>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();


        public AppIdentityUser? AppIdentityUser { get; set; }

    }
}
