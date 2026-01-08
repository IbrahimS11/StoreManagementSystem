using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.ProductUnitPrice
{
    public class ProductUnitPriceCreateDto
    {
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
