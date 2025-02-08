using System;
using System.Collections.Generic;
using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Data;

public partial class ExpenseManagerDbContext : DbContext
{
    public ExpenseManagerDbContext()
    {
    }

    public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseCreation> ExpenseCreations { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCreation>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__ExpenseC__1445CFD383FADF9D");

            entity.ToTable("ExpenseCreation");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExpenseName)
                .HasMaxLength(100)
                .HasColumnName("Expense_Name");
            entity.Property(e => e.ExpenseType)
                .HasMaxLength(100)
                .HasColumnName("Expense_Type");

            entity.HasOne(d => d.Salary).WithMany(p => p.ExpenseCreations)
                .HasForeignKey(d => d.SalaryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Expense_Salary");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.Property(e => e.SalaryId).HasColumnName("Salary_Id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalaryExpense)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Salary_Expense");
            entity.Property(e => e.SalarySavings)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Salary_Savings");
            entity.Property(e => e.SalarySource).HasColumnName("Salary_Source");
            entity.Property(e => e.SalaryType).HasColumnName("Salary_Type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
