using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("transaction")]
    public class Transaction
    {
        [Key]
        [Column("transaction_id")]
        public int transactionId { get; set; }

        [Required]
        [Column("date_transaction")]
        public DateTime dateTransaction { get; set; }

        [Required]
        [ForeignKey("transaction_type_id")]
        [Column("transaction_type_id")]
        public int transactionTypeId { get; set; }

        [Required]
        [ForeignKey("account_sender")]
        [Column("account_sender")]
        public int accountSender { get; set; }

        [Required]
        [ForeignKey("account_receiver")]
        [Column("account_receiver")]
        public int accountReceiver { get; set; }

        [Required]
        [Column("transaction_value")]
        public double transactionValue { get; set; } = 0.0;

        public TransactionType TransactionType { get; set; } = null!;
        public Account SenderAccount { get; set; } = null!;
        public Account ReceiverAccount { get; set; } = null!;


    }
}
