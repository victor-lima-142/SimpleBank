using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("person")]
    public class Person
    {
        [Key]
        public int personid { get; set; }

        [Required]
        public String name{ get; set; }

        [Required]
        public String lastname { get; set; }

        [Required]
        public String taxid { get; set; }

        [Required]
        public DateTime birthday { get; set; }

        [Required]
        [ForeignKey("userid")]
        public int userid { get; set; }
    }
}
