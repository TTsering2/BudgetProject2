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

    public async Task<ExpenseReportDTO>? GetExpenseReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
    {
 
        //grab all expenses from a given date range
        IEnumerable<ExpenseDTO> expenses = await _expenseRepository.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate);
        
        //group expenses by type
        Dictionary<string, decimal> expensesByType = new Dictionary<string, decimal>();

        foreach(ExpenseDTO expense in expenses)
        {
            if(expensesByType.ContainsKey(expense.Type))
            {
                expensesByType[expense.Type] += expense.Amount;
            }
            else
            {
                expensesByType.Add(expense.Type, expense.Amount);
            }
        }

        //TODOgrab top 3 expenses
        List<ExpenseDTO> big3Expenses = new List<ExpenseDTO>();
        big3Expenses = expenses.OrderByDescending(e => e.Amount).Take(3).ToList();

        //map the expensesByType, startDate, endDate, and big3Expenses to a BudgetReportDTO
        ExpenseReportDTO expenseReport = new ExpenseReportDTO
        {
            StartDate = startDate,
            EndDate = endDate,
            ExpensesByCategory = expensesByType,
            Top3Expenses = big3Expenses
        };

        return expenseReport;
    }

    public async Task<IncomeReportDTO?> GetIncomeReportByDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
    {        
        //grab all expenses from a given date range
        IEnumerable<IncomeDTO> incomes = await _incomeRepository.GetIncomeByUserIdAndDateRangeAsync(userId, startDate, endDate);
        
        //group expenses by type
        Dictionary<string, decimal> incomesByType = new Dictionary<string, decimal>();

        foreach(IncomeDTO income in incomes)
        {
            if(incomesByType.ContainsKey(income.Type))
            {
                incomesByType[income.Type] += income.Amount;
            }
            else
            {
                incomesByType.Add(income.Type, income.Amount);
            }
        }

        List<IncomeDTO> big3Incomes = new List<IncomeDTO>();
        big3Incomes = incomes.OrderByDescending(e => e.Amount).Take(3).ToList();

        //map the expensesByType, startDate, endDate, and big3Expenses to a BudgetReportDTO
        IncomeReportDTO incomeReport = new IncomeReportDTO()
        {
            StartDate = startDate,
            EndDate = endDate,
            IncomeByCategory = incomesByType,
            Top3Incomes = big3Incomes
        };

        return incomeReport;

    }
}