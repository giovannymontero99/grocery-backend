using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroceryBackend.src.Domain.Entities {

    [Table("user_products", Schema = "public")]
    public class UserProduct
    {
        [Key]
        [Column("user_product_id")]
        public int UserProductId { get; set; }

        [Required]
        [Column("user_user")]
        public int UserId { get; set; }

        [Required]
        [Column("product_product")]
        public int ProductId { get; set; } 

        [Column("user_product_quantity")]
        public int Quantity { get; set; } = 1;

        [Column("user_product_added_at")]
        public DateTime? AddedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
