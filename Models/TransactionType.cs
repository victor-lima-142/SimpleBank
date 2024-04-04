using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("transaction_types")]
    public class TransactionType
    {

        [Key]
        [Column("transaction_type_id")]
        public int transactionTypeId { get; set; }

        [Required]
        [Column("transaction_type_name")]
        public string transactionTypeName { get; set; }

        public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
    }
}
