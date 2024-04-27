using Budgets.Models;
using Budgets.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Budgets.Data;

public class ExpenseRepository : IExpenseRepository
{
    private readonly BudgetsDbContext _context;
    public ExpenseRepository(BudgetsDbContext context)
    {
        _context = context;
    }

    // Get all Expenses for a given User
    public async Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAsync(int userId) 
    {
        IEnumerable<ExpenseDTO> expenses = await _context.Expenses
            .Where(e => e.UserId == userId)
            .Include(e => e.User)
            .Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Title = e.Title,
                Type = e.Type,
                Amount = e.Amount,
                Date = e.Date,
                Username = e.User.Username
            })
            .ToListAsync();

        return expenses;
    }

    // Get expense by userId and expenseId
    public async ExpenseDTO GetByUserIdAndExpenseIdAsync(int userId, int expenseId)
    {
        ExpenseDTO expense = await _context.Expenses
            .Where(e => e.UserId == userId && e.Id == expenseId)
            .Include(e => e.User)
            .Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Title = e.Title,
                Type = e.Type,
                Amount = e.Amount,
                Date = e.Date,
                Username = e.User.Username
            })
            .FirstOrDefaultAsync();
        return expense;
    } 

    //Get expense by userId and expense type
    public async Task<IEnumerable<ExpenseDTO>>? GetByUserIdAndExpenseTypeAsync(int userId, string expenseType)
    {
        IEnumerable<ExpenseDTO> expenses = await _context.Expenses
            .Where(e => e.UserId == userId && e.Type == expenseType)
            .Include(e => e.User)
            .Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Title = e.Title,
                Type = e.Type,
                Amount = e.Amount,
                Date = e.Date,
                Username = e.User.Username
            })
            .ToListAsync();
        return expenses;
    }

    public async Task AddAnExpenseAsync(ExpenseCreateDTO entity)
    {
        Expense newExpense = new Expense 
        {
            Title = entity.Title,
            Type = entity.Type,
            Amount = entity.Amount,
            Date = entity.Date,
            UserId = entity.UserId
        }

        _context.Expenses.Add(newExpense);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnExpenseAsync(int expenseId)
    {
        Expense expense = await _context.Expenses.FindAsync(expenseId);

        if(expense == null){
            throw new Exception($"Expense with ID {expenseId} not found.");
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
    } 

    public async Task UpdateAnExpenseAsync(int expenseId, ExpenseUpdateDTO entity)
    {
        //find expense first by id
        Expense expense = await _context.Expenses
            .Include(e => e.User) //include user info
            .FirstOrDefaultAsync(e => e.Id == expenseId);

        if(expense == null)
        {
            throw new Exception($"Expense with ID {expenseId} not found.");
        }

        expense = {
            Title == null ? expense.Title : entity.Title,
            Type == null ? expense.Type : entity.Type,
            Amount == null ? expense.Amount : entity.Amount,
            Date == null ? expense.Date : entity.Date
        }

        await _context.SaveChangesAsync();
    }        
}