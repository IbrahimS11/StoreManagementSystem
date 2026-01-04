using StoreManagementSystem.Models.Inventories;

namespace StoreManagementSystem.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;



        public int ProductUnitPriceId { get; set; }
        public ProductUnitPrice ProductUnitPrice { get; set; } = null!;



        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;



        public int ProductFlavorId { get; set; }
        public ProductFlavor ProductFlavor { get; set; } = null!;


        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


    }
}
