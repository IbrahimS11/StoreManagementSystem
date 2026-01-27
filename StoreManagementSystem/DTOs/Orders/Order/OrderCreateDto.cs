using StoreManagementSystem.DTOs.Orders.OrderItem;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Orders.Order
{
    public class OrderCreateDto
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string CustomerPhone { get; set; } = null!;
        public IEnumerable<OrderItemCreateDto> OrderItems { get; set; } =new List<OrderItemCreateDto>();



    }
}
