using System;
using System.Collections.Generic;

namespace SimpleBank.Models;

public partial class Account
{
    public long AccountId { get; set; }

    public string Agency { get; set; } = null!;

    public string Number { get; set; } = null!;

    public decimal StartingCapital { get; set; }

    public decimal Balance { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public virtual ICollection<Transaction> TransactionAccountReceiverNavigations { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionAccountSenderNavigations { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
