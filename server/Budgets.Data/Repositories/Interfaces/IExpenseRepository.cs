using Budgets.Models;
using Budgets.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Budgets.Data;

public interface IExpenseRepository
{
    Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAsync(int userId);
    Task<ExpenseDTO>? GetExpenseByUserIdAndExpenseIdAsync(int userId, int expenseId);
    Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAndExpenseTypeAsync(int userId, string expenseType);
    Task AddAnExpenseAsync(ExpenseCreateDTO expense);
    Task DeleteAnExpenseAsync(int expenseId);
    Task UpdateAnExpenseAsync(int expenseId, ExpenseUpdateDTO expense);
    Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
}