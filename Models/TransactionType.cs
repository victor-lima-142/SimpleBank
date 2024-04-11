using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("transaction_types")]
    public class TransactionType
    {

        [Key]
        [Column("transaction_type_id")]
        public int TransactionTypeId { get; set; }

        [Required]
        [Column("transaction_type_name")]
        public string transactionTypeName { get; set; }
    }
}
