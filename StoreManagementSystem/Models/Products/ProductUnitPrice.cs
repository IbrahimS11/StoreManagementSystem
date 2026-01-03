namespace StoreManagementSystem.Models.Products
{
    public class ProductUnitPrice
    {
        public int UnitPrice { get; set; }
        ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
