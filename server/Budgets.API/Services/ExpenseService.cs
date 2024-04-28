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

    public async Task<ExpenseDTO>? GetByUserIdAndExpenseIdAsync(int userId, int expenseId)
    {
        return await _repository.GetByUserIdAndExpenseIdAsync(userId, expenseId);
    }

    public async Task<IEnumerable<ExpenseDTO>>? GetByUserIdAndExpenseTypeAsync(int userId, string expenseType)
    {
        return await _repository.GetByUserIdAndExpenseTypeAsync(userId, expenseType);
    }

    public async Task AddAnExpenseAsync(ExpenseCreateDTO entity)
    {
        await _repository.AddAnExpenseAsync(entity);
    }

    public async Task DeleteAnExpenseAsync(int expenseId){
        await _repository.DeleteAnExpenseAsync(expenseId);  
    }

    public async Task UpdateAnExpenseAsync(int expenseId, ExpenseUpdateDTO entity){
        await _repository.UpdateAnExpenseAsync(expenseId, entity);
    }
}