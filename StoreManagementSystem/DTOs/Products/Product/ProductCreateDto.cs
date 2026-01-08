using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.Product
{
    public class ProductCreateDto
    {
        [Required]
        [Range(0.01, 1_000_000, ErrorMessage = "Price Is Not Valid")]
        public decimal Price { get; set; }



        [MaxLength(150, ErrorMessage = "Must be Less than 150 character")]
        public string? Description { get; set; }



        public string? ImageUrl { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PriceId Is Not Valid")]
        public int ProductUnitPriceId { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId Is Not Valid")]
        public int CategoryId { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "FlavorId Is Not Valid")]
        public int ProductFlavorId { get; set; }
    }
}
