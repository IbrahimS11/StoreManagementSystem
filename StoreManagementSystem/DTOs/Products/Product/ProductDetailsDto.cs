using StoreManagementSystem.DTOs.Products.Category;
using StoreManagementSystem.DTOs.Products.ProductFlavor;
using StoreManagementSystem.DTOs.Products.ProductUnitPrice;

namespace StoreManagementSystem.DTOs.Products.Product
{
    public class ProductDetailsDto
    {
       
            public int Id { get; set; }
            public decimal Price { get; set; }
            public string? Description { get; set; }
            public string? ImageUrl { get; set; }

            public CategoryReadDto Category { get; set; } = null!;
            public ProductFlavorReadDto ProductFlavor { get; set; } = null!;
            public ProductUnitPriceReadDto ProductUnitPrice { get; set; } = null!;
        
    }
}
