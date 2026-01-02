namespace StoreManagementSystem.Models.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}
