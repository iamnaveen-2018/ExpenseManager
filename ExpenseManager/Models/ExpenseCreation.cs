using System;
using System.Collections.Generic;

namespace ExpenseManager.Models;

public partial class ExpenseCreation
{
    public int ExpenseId { get; set; }

    public string ExpenseName { get; set; } = null!;

    public string ExpenseType { get; set; } = null!;

    public string? Description { get; set; }

    public int? SalaryId { get; set; }

    public virtual Salary? Salary { get; set; }
}
