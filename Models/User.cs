using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("user")]
    public class User
    {

        [Key]
        public int userid { get; set; }

        [Required]
        public required String email { get; set; }

        [Required]
        public required String password { get; set; }

        [Required]
        [ForeignKey("accountid")]
        public int accountid{ get; set; }
    }
}
