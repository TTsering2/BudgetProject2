using Budgets.Models;
using Budgets.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Budgets.Data;

public interface IExpenseRepository
{
    Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAsync(int userId);
    Task<ExpenseDTO>? GetByUserIdAndExpenseIdAsync(int userId, int expenseId);
    Task<IEnumerable<ExpenseDTO>>? GetByUserIdAndExpenseTypeAsync(int userId, string expenseType);
    Task AddAnExpenseAsync(ExpenseCreateDTO expense);
    Task DeleteAnExpenseAsync(int expenseId);
    Task UpdateAnExpenseAsync(int expenseId, ExpenseUpdateDTO expense);
}