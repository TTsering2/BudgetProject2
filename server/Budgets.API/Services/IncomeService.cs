using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;

public class IncomeService : IIncomeService{

    private readonly IIncomeRepository _repo;
    public IncomeService (IIncomeRepository repo){
        _repo = repo;
    }



    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAsync(int userId){
        return await _repo.GetIncomeByUserIdAsync(userId);
    }
    public async Task<IncomeDTO>? GetIncomeByUserIdAndIncomeIdAsync(int userId, int incomeId){
        return await _repo.GetIncomeByUserIdAndIncomeIdAsync(userId, incomeId);
    }
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndIncomeTypeAsync(int userId, string incomeType){
        return await _repo.GetIncomeByUserIdAndIncomeTypeAsync(userId,incomeType);
    }
    public async Task AddAnIncomeAsync(IncomeCreateDTO entity){
        await _repo.AddAnIncomeAsync(entity);
    }
    public async Task DeleteAnIncomeAsync(int incomeId){
        await _repo.DeleteAnIncomeAsync(incomeId);
    }

    public async Task UpdateAnIncomeAsync(int incomeId, IncomeUpdateDTO entity){
        await _repo.UpdatAnIncomeeAsync(incomeId, entity);
    }
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate){
        return await _repo.GetIncomeByUserIdAndDateRangeAsync(userId, startDate,endDate);
    }
}


