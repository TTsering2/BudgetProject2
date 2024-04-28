using Budgets.Models;
using Budgets.DTOs;
using Budgets.Data;

namespace Budgets.Services;

public interface IBudgetReportService
{
    Task<ExpenseReportDTO> GetExpenseReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
}