namespace GroceryBackend.src.Application.DTO
{
    public class UserProductDto
    {
        public int UserProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public DateTime? AddedAt { get; set; } = DateTime.UtcNow;

        public int IdUser { get; set; }

        public int IdProduct { get; set; }

        public bool IsSaved { get; set; } = false;

        public ProductsDto? Products { get; set; }
    }
}
