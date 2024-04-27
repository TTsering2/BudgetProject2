using Budgets.Models;
using Budgets.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Budgets.Data;

public interface IExpenseRepository
{
    //Want to grab all expenses by a userId first
    public Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAsync(int userId);
    public ExpenseDTO? GetByUserIdAndExpenseIdAsync(int userId, int expenseId);
    public Task<IEnumerable<ExpenseDTO>>? GetByUserIdAndExpenseTypeAsync(int userId, string expenseType);
    public Task AddAnExpenseAsync(CreateExpenseDTO expense);
    public Task DeleteAnExpenseAsync(int expenseId);
    public Task UpdateAnExpenseAsync(int expenseId, UpdateExpenseDTO expense);
}