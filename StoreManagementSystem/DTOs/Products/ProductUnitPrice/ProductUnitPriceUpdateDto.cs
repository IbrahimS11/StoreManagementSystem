using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.ProductUnitPrice
{
    public class ProductUnitPriceUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
