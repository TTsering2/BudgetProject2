using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;
using Budgets.Validators;

namespace Budgets.Services;

public class IncomeService : IIncomeService{

    private readonly IIncomeRepository _incomerepo;

    private readonly ILogger<IncomeService> _logger;        
    public IncomeService (IIncomeRepository incomerepo, ILogger<IncomeService> logger){
        _incomerepo = incomerepo;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// By adding ! after the method call (GetIncomeByUserIdAsync(userId)!), 
    /// you're explicitly telling the compiler that you're sure the result 
    /// will not be null, thus suppressing the warning
    /// 
    /// </summary>
    /// 



    //** However, ensure that the method GetIncomeByUserIdAsync 
     ///indeed does not return null in all cases, otherwise, 
     ///you might encounter null reference exceptions at runtime. ***


    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAsync(int userId)
    {
        try
        {
            return await _incomerepo.GetIncomeByUserIdAsync(userId)!;
        }
        catch(Exception ex){
            _logger.LogError(ex, "Error occurred while retrieving income by user ID: {UserId}", userId);
            throw;
        }
    }

    public async Task<IncomeDTO>? GetIncomeByUserIdAndIncomeIdAsync(int userId, int incomeId){
        try
        {
            return await _incomerepo.GetIncomeByUserIdAndIncomeIdAsync(userId, incomeId)!;
        }
        catch(Exception ex){
            _logger.LogError(ex,"Error occurred while retrieving income ID {UserID} and income ID {IncomeID}", userId, incomeId);
            throw;
        }
    }

    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndIncomeTypeAsync(int userId, string incomeType){
        return await _incomerepo.GetIncomeByUserIdAndIncomeTypeAsync(userId,incomeType)!;
    }


    public async Task AddAnIncomeAsync(IncomeCreateDTO entity)
    {
        try
        {
             if(ValidatorIncome.ValidateAllIncome(entity.Title, entity.Type,(decimal) entity.Amount))
             {
                await _incomerepo.AddAnIncomeAsync(entity);
             }

        }
        catch(Exception ex){
            _logger.LogError(ex,"Error occurred while adding income: {Income}", entity);

        }
    }
    public async Task DeleteAnIncomeAsync(int incomeId){
        try
        {
            await _incomerepo.DeleteAnIncomeAsync(incomeId);

        }
        catch(Exception ex){
            _logger.LogError(ex, "Error occurred while deleting income {incomeID}",incomeId);
        }
        
    }

    public async Task UpdateAnIncomeAsync(int incomeId, IncomeUpdateDTO entity){

        try
        {
            if(ValidatorIncome.ValidateAllIncome(entity.Title, entity.Type,(decimal) entity.Amount))
            {
                await _incomerepo.UpdatAnIncomeeAsync(incomeId, entity);
            }

        }
        catch(Exception ex){
            _logger.LogError(ex,"Error occurred while updating income with ID {IncomeID}: {Income}", incomeId,entity);
        }
       

    }
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate){
        try
        {
            return await _incomerepo.GetIncomeByUserIdAndDateRangeAsync(userId, startDate,endDate)!;

        }
        catch(Exception ex){
            _logger.LogError(ex,"Error occurred while retrieving income ID {UserId} and date range ({StartDate}-{EndDate})", userId, startDate,endDate);
            throw;

        }
        
    }
}


