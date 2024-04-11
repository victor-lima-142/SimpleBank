using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SimpleBank.Data;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("person")]
    public class Person
    {
        [Key]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Required]
        [Column("name")]
        public required string PersonName { get; set; }

        [Required]
        [Column("last_name")]
        public required string PersonLastName { get; set; }

        [Required]
        [Column("tax_id")]
        public required string TaxId { get; set; }

        [Required]
        [Column("PersonBirthday")]
        public required DateTime PersonBirthday { get; set; } = DateTime.Now;

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
