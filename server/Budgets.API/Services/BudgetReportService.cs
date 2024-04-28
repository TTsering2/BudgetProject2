using Budgets.Models;
using Budgets.DTOs;
using Budgets.Data;

namespace Budgets.Services;

public class BudgetReportService : IBudgetReportService 
{
    private readonly IIncomeRepository _incomeRepository;
    private readonly IExpenseRepository _expenseRepository;

    public BudgetReportService(IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
    {
        _incomeRepository = incomeRepository;
        _expenseRepository = expenseRepository;
    }

    public async Task<BudgetReportDTO>? GetExpenseReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
    {
        try
        {
            //grab all expenses from a given date range
            IEnumerable<ExpenseDTO> expenses = await _expenseRepository.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate);
            if(expenses == null || !expenses.Any())
            {
                return "No expenses found for the given date range and User.";
            }

            //group expenses by type
            Dictionary<string, decimal> expensesByType = new Dictionary<string, decimal>();

            foreach(ExpenseDTO expense in expenses)
            {
                if(expensesByType.ContainsKey(expense.Type))
                {
                    expensesByType[expense.Type].Amount += expense.Amount;
                }
                else
                {
                    expensesByType.Add(expense.Type, expense.Amount);
                }
            }

            //TODOgrab top 3 expenses
            List<ExpenseDTO> big3Expenses = new List<ExpenseDTO>();

            //map the expensesByType, startDate, endDate, and big3Expenses to a BudgetReportDTO
            BudgetReportDTO expenseReport = new BudgetReportDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                ExpensesByType = expensesByType,
                Top3Expenses = big3Expenses
            };

            return expenseReport;
        } 
        catch (Exception ex)
        {
            return $"Error retrieving expenses: {ex.Message}";
        }
    }
}