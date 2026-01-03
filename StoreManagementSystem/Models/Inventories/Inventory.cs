namespace StoreManagementSystem.Models.Inventories
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public int Quantity { get; set;}
        public DateOnly ExpiryDate { get; set; }



        [ForeignKey("PurchaseItem")]
        public Guid PurchaseItemId { get; set; }
        public PurchaseItem PurchaseItem { get; set; } = null!;


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;




    }
}
