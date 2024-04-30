using Budgets.Models;
using Budgets.DTOs;
using Budgets.Data;

/*      Interface for Income service    */
namespace Budgets.Services;
public interface IIncomeService
{

    Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAsync(int userId);
    Task<IncomeDTO>? GetIncomeByUserIdAndIncomeIdAsync(int userId, int incomeId);
    Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndIncomeTypeAsync(int userId, string incomeType);
    Task AddAnIncomeAsync(IncomeCreateDTO income);
    Task DeleteAnIncomeAsync(int incomeId);
    Task UpdateAnIncomeAsync(int incomeId, IncomeUpdateDTO income);
    Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate);

}