using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.ProductFlavor
{
    public class ProductFlavorUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
