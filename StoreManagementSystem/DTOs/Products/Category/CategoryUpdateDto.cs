using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.DTOs.Products.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
