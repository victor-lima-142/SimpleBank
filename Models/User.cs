using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("user")]
    public class User
    {

        [Key]
        [Column("user_id")]
        public int userId { get; set; }

        [Required]
        [Column("email")]
        public String email { get; set; }

        [Required]
        [Column("password")]
        public String password { get; set; }

        [Required]
        [Column("account_id")]
        [ForeignKey("account_id")]
        public int accountId { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? deletedAt { get; set; } = null;
    }
}
