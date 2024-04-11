using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SimpleBank.Data;

namespace SimpleBank.Models
{
    [Table("account")]
    public class Account
    {

        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("agency")]
        public required string Agency { get; set; }

        [Required]
        [Column("number")]
        public required string AccountNumber { get; set; }

        [Required]
        [Column("balance")]
        public double Balance { get; set; } = 0.0;

        [Required]
        [Column("starting_capital")]
        public double StartingCapital { get; set; } = 0.0;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
