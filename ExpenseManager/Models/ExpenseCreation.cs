using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExpenseManager.Models;

public partial class ExpenseCreation
{
    public int ExpenseId { get; set; }

    public string ExpenseName { get; set; } = null!;

    public string ExpenseType { get; set; } = null!;

    public string? Description { get; set; }

    public int? SalaryId { get; set; }

    public int ExpenseAmount { get; set; }

    [JsonIgnore]
    public virtual Salary? Salary { get; set; }
}
