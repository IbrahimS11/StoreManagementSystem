using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Orders.OrderItem
{
    public class OrderItemCreateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "Quntity must between 1 and 200")]
        public int Quantity { get; set; } 
    }
}
