using StoreManagementSystem.Models.Locations;

namespace StoreManagementSystem.Models.Customers
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public string? Details { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        [ForeignKey("Street")]
        public int StreetId { get; set; }
        public Street Street { get; set; } = null!;


        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

       

    }
}
