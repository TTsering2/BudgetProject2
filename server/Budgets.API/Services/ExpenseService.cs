using Budgets.Models;
using Budgets.DTOs;
using Budgets.Data;

namespace Budgets.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;
    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAsync(int userId)
    {
        return await _repository.GetExpensesByUserIdAsync(userId);
    }

    public async Task<ExpenseDTO>? GetExpenseByUserIdAndExpenseIdAsync(int userId, int expenseId)
    {
        return await _repository.GetExpenseByUserIdAndExpenseIdAsync(userId, expenseId);
    }

    public async Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAndExpenseTypeAsync(int userId, string expenseType)
    {
        return await _repository.GetExpensesByUserIdAndExpenseTypeAsync(userId, expenseType);
    }

    public async Task AddAnExpenseAsync(ExpenseCreateDTO entity)
    {
        await _repository.AddAnExpenseAsync(entity);
    }

    public async Task DeleteAnExpenseAsync(int expenseId)
    {
        await _repository.DeleteAnExpenseAsync(expenseId);  
    }

    public async Task UpdateAnExpenseAsync(int expenseId, ExpenseUpdateDTO entity)
    {
        await _repository.UpdateAnExpenseAsync(expenseId, entity);
    }

    public async Task<IEnumerable<ExpenseDTO>>? GetExpensesByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
    {
        return await _repository.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate);
    }
}