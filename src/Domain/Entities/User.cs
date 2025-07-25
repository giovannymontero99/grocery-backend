using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryBackend.src.Domain.Entities
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key]
        [Column("user_user")]
        public int UserId { get; set; }

        [Required] // NOT NULL in BD
        [Column("user_username")]
        public required string UserName { get; set; }

        [Column("user_email")]
        public string? Email { get; set; }

        [Column("user_phone")]
        public string? Phone { get; set; }

        [Required]
        [Column("user_password")]
        public string PasswordHash { get; set; }

        [Column("user_fullname")]
        public string? FullName { get; set; }

    }
}
