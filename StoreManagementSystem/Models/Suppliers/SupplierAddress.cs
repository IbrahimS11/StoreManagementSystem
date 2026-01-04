namespace StoreManagementSystem.Models.Suppliers
{
    public class SupplierAddress
    {
        public Guid Id { get; set; }


        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;


        public int StreetId { get; set; }
        public Street Street { get; set; } = null!;



        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public string? Details { get; set; }
    }
}
