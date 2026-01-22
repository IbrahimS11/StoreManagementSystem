
namespace StoreManagementSystem.DTOs.Products.Product
{
    public class ProductReadDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int ProductUnitPriceId { get; set; }
        public decimal ProductUnitPrice { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public int ProductFlavorId { get; set; }
        public string ProductFlavor { get; set; } = null!;
    }
}
