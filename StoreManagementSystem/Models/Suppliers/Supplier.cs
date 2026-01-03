using StoreManagementSystem.Models.Inventories;

namespace StoreManagementSystem.Models.Suppliers
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;


        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public SupplierAddress Address { get; set; } = null!;

        public ICollection<SupplierPayment> Payments { get; set; } = new List<SupplierPayment>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
