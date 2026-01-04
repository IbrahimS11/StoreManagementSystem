namespace StoreManagementSystem.Models.Products
{
    public class ProductUnitPrice
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
