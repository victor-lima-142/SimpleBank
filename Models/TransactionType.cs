using System;
using System.Collections.Generic;

namespace SimpleBank.Models;

public partial class TransactionType
{
    public long TransactionTypeId { get; set; }

    public string TransactionTypeName { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
