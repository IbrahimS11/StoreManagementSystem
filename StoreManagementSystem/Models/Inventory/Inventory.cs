namespace StoreManagementSystem.Models.Inventory
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public int Quantity { get; set;}
        public DateOnly ExpiryDate { get; set; }
       
    
    }
}
