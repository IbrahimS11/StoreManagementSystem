namespace StoreManagementSystem.Models.Inventories
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Note { get; set; } = null!;


        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;


        [ForeignKey("SupplierPayment")]
        public Guid SupplierPaymentId { get; set; }
        public SupplierPayment SupplierPayment { get; set; } = null!;

        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    }
}
