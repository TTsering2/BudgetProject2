using Budgets.Models;
using Budgets.DTOs;
using Budgets.Data;

namespace Budgets.Services;

public interface IBudgetReportService
{
    Task<ExpenseReportDTO> GetExpenseReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
    // Task<IncomeReportDTO> GetIncomeReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
    // Task<SummaryReportDTO> GetSummaryReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);

}