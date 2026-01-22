namespace StoreManagementSystem.DTOs.Products.Category

{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
