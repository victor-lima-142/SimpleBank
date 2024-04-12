using System;
using System.Collections.Generic;

namespace SimpleBank.Models;

public partial class User
{
    public long UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public long? AccountId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Person? Person { get; set; }
}
