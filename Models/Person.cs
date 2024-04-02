using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("person")]
    public class Person
    {
        [Key]
        [Column("person_id")]
        public int personId { get; set; }

        [Required]
        [Column("name")]
        public String name { get; set; }

        [Required]
        [Column("last_name")]
        public String lastName { get; set; }

        [Required]
        [Column("tax_id")]
        public String taxId { get; set; }

        [Required]
        [Column("birthday")]
        public DateTime birthday { get; set; } = DateTime.Now;

        [Required]
        [Column("user_id")]
        [ForeignKey("user_id")]
        public int userId { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? deletedAt { get; set; } = null;
    }
}
