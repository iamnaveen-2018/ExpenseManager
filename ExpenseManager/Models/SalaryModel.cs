using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ExpenseManager.Models
{
    public class SalaryModel
    {
        [Key]
        [Required]
        public int Salary_Id { get; set; }

        [Required] 
        public string? Salary_Source { get; set; }

        [Required]
        public string? Salary_Type { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Salary_Expense { get; set; }

        [Required]
        public decimal Salary_Savings { get; set; }
    }
}
