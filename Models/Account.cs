using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

interface IAccountUpdate
{
    String? agency { get; set; }
    String? number { get; set; }
    double? startingcapital { get; set; }
    double? balance { get; set; }
}

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("account")]
    public class Account
    {

        [Key]
        public int accountid { get; set; }

        public String agency { get; set; }

        public String number { get; set; }
        
        public double? startingcapital { get; set; }

        [Required]
        public double balance { get; set; }
        
        public DateTime createdat { get; set; }
        public DateTime? deletedat { get; set; }

        public static implicit operator Account(ActionResult<Account> v)
        {
            throw new NotImplementedException();
        }
    }
}
