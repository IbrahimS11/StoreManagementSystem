using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.ProductUnitPrice
{
    public class ProductUnitPriceCreateDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
