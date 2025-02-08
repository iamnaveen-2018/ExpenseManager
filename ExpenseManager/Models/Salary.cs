using System;
using System.Collections.Generic;

namespace ExpenseManager.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public string SalarySource { get; set; } = null!;

    public string SalaryType { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public decimal SalaryExpense { get; set; }

    public decimal SalarySavings { get; set; }

    public virtual ICollection<ExpenseCreation> ExpenseCreations { get; set; } = new List<ExpenseCreation>();
}
