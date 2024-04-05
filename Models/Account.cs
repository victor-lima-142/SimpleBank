using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SimpleBank.Models
{
    [Table("account")]
    public class Account
    {

        [Key]
        [Column("account_id")]
        public int accountId { get; set; }

        [Required]
        [Column("agency")]
        public String agency { get; set; }

        [Required]
        [Column("number")]
        public String number { get; set; }

        [Required]
        [Column("balance")]
        public double balance { get; set; } = 0;

        [Required]
        [Column("starting_capital")]
        public double startingCapital { get; set; } = 0;

        [Column("created_at")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? deletedAt { get; set; } = null;
    }
}
