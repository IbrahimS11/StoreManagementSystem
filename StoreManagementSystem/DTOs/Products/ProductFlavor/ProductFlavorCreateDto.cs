using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.ProductFlavor
{
    public class ProductFlavorCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
