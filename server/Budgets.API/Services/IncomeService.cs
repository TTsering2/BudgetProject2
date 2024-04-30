using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;

public class IncomeService : IIncomeService{

    private readonly IIncomeRepository _incomerepo;
    public IncomeService (IIncomeRepository incomerepo){
        _incomerepo = incomerepo;
    }

    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAsync(int userId){
        return await _incomerepo.GetIncomeByUserIdAsync(userId);
    }
    public async Task<IncomeDTO>? GetIncomeByUserIdAndIncomeIdAsync(int userId, int incomeId){
        return await _incomerepo.GetIncomeByUserIdAndIncomeIdAsync(userId, incomeId);
    }
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndIncomeTypeAsync(int userId, string incomeType){
        return await _incomerepo.GetIncomeByUserIdAndIncomeTypeAsync(userId,incomeType);
    }
    public async Task AddAnIncomeAsync(IncomeCreateDTO entity){
        await _incomerepo.AddAnIncomeAsync(entity);
    }
    public async Task DeleteAnIncomeAsync(int incomeId){
        await _incomerepo.DeleteAnIncomeAsync(incomeId);
    }

    public async Task UpdateAnIncomeAsync(int incomeId, IncomeUpdateDTO entity){
        await _incomerepo.UpdatAnIncomeeAsync(incomeId, entity);
    }
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate){
        return await _incomerepo.GetIncomeByUserIdAndDateRangeAsync(userId, startDate,endDate);
    }
}


