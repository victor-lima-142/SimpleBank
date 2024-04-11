using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("transactions")]
    public class Transaction
    {
        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Required]
        [Column("date_transaction")]
        public DateTime DateTransaction { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("transaction_value")]
        public double TransactionValue { get; set; } = 0.0;

        [Required]
        [Column("transaction_type_id")]
        public int TransactionTypeId { get; set; }

        [Required]
        [Column("account_sender")]
        public int AccountSender { get; set; }

        [Required]
        [Column("account_receiver")]
        public int AccountReceiver { get; set; }
    }
}
