namespace StoreManagementSystem.Models.Products
{
    public class ProductFlavor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
