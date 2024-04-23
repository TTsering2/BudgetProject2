using Microsoft.EntityFrameworkCore;
using Budgets.Models;
namespace Budgets.Data;

public class BudgetsDbContext : DbContext
{
    public BudgetsDbContext() : base() {}
    public BudgetsDbContext(DbContextOptions<BudgetsDbContext> options) : base(options){}
    public DbSet<User> Users { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Income> Incomes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User configuration
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Expenses)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Incomes)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Stocks)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Expense configuration
        modelBuilder.Entity<Expense>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Expense>()
            .Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)"); 

        // Income configuration
        modelBuilder.Entity<Income>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<Income>()
            .Property(i => i.Amount)
            .HasColumnType("decimal(18, 2)"); 
        // Stock configuration
        modelBuilder.Entity<Stock>()
            .HasKey(s => s.Id);

        base.OnModelCreating(modelBuilder);
    }
}