using System;
using System.Collections.Generic;

namespace SimpleBank.Models;

public partial class Transaction
{
    public long TransactionId { get; set; }

    public DateOnly DateTransaction { get; set; }

    public long TransactionTypeId { get; set; }

    public long AccountSender { get; set; }

    public long AccountReceiver { get; set; }

    public decimal TransactionValue { get; set; }

    public virtual Account AccountReceiverNavigation { get; set; } = null!;

    public virtual Account AccountSenderNavigation { get; set; } = null!;

    public virtual TransactionType TransactionType { get; set; } = null!;
}
