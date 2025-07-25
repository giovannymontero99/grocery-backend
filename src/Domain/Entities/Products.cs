using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryBackend.src.Domain.Entities
{
    [Table("products", Schema = "public")]
    public class Products
    {
        [Key]
        [Column("product_product")]
        public int ProductId { get; set; }

        [Required]
        [Column("product_name")]
        public string Name { get; set; }

        [Column("product_description")]
        public string? Description { get; set; }

        [Required]
        [Column("product_price")]
        public double Price { get; set;}

        [Required]
        [Column("product_category")]
        public string Category { get; set;}

        [Column("product_created_at")]
        public DateTime? CreatedAt { get; set;}

        [Column("product_updated_at")]
        public DateTime? UpdatedAt { get;}

        [Column("product_is_active")]
        public Boolean? IsActive { get; set;}
    }
}
