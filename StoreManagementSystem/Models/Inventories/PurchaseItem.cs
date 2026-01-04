namespace StoreManagementSystem.Models.Inventories
{
    public class PurchaseItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [ForeignKey("Purchase")]
        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Inventory? Inventory { get; set; }
    }
}
