namespace StoreManagementSystem.Models.Inventories
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public int Quantity { get; set;}




        public Guid PurchaseItemId { get; set; }
        public PurchaseItem PurchaseItem { get; set; } = null!;



        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;




    }
}
