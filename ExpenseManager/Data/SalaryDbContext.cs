using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Data
{
    public class SalaryDbContext : DbContext
    {
        public SalaryDbContext(DbContextOptions<SalaryDbContext> options) : base(options)
        {

        }

        public DbSet<SalaryModel> Salaries { get; set; }

    }
}
