using System;
using System.Collections.Generic;

namespace SimpleBank.Models;

public partial class Person
{
    public long PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string TaxId { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public long? UserId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public virtual User? User { get; set; }
}
