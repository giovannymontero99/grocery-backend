namespace GroceryBackend.src.Application.DTO
{
    public class ProductsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; }

        public Boolean? IsActive { get; set; }
    }
}
