using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimpleBank.Data;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("user")]
    public class User
    {

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("email")]
        public required string Email { get; set; }

        [Required]
        [Column("password")]
        public required string Password { get; set; }

        [Required]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
