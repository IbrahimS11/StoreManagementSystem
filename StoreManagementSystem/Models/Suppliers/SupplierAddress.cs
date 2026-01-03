namespace StoreManagementSystem.Models.Suppliers
{
    public class SupplierAddress
    {
        public Guid Id { get; set; }

        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        [ForeignKey("Street")]
        public int StreetId { get; set; }
        public Street Street { get; set; } = null!;


        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public string? Details { get; set; }
    }
}
