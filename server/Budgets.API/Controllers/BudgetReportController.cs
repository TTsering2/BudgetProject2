using Microsoft. AspNetCore.Mvc;
using Budgets.Services;
using Budgets.DTOs;


namespace Budgets.Controller;

public class BudgetReportController : ControllerBase
{   
    private readonly IBudgetReportService _budgetReportService;

    public BudgetReportController(IBudgetReportService budgetReportService)
    {
        _budgetReportService = budgetReportService;
    }

    //Get expense report by date range
    //GET: api/budgetreport/expenseReport/userId={userId}/startDate={startDate}/endDate={endDate}
    [HttpGet("expenseReport/userId={userId}/startDate={startDate}/endDate={endDate}")]
    public async Task<ActionResult<ExpenseReportDTO>> GetExpenseReportByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        try
        {
            ExpenseReportDTO expenseReport = await _budgetReportService.GetExpenseReportByDateRangeAsync(userId, startDate, endDate);
            if(expenseReport == null)
            {
                return NotFound("No expenses found for the given date range and User.");
            }
            return Ok(expenseReport);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving expenses: {ex.Message}");
        }
    }

    //Get income report by date range
    //GET: api/budgetreport/incomeReport/userId={userId}/startDate={startDate}/endDate={endDate}
    [HttpGet("incomeReport/userId={userId}/startDate={startDate}/endDate={endDate}")]
    public async Task<ActionResult<IncomeReportDTO>> GetIncomeReportByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        try{
            IncomeReportDTO incomeReport = await _budgetReportService.GetIncomeReportByDateRangeAsync(userId, startDate, endDate);
            if(incomeReport == null)
            {
                return NotFound("No incomes found for the given date range and User.");
            }
            return Ok(incomeReport);
        } 
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving incomes: {ex.Message}");
        }
    }

    //Get balance report by date range
    //GET: api/budgetreport/balanceReport/userId={userId}/startDate={startDate}/endDate={endDate}
    [HttpGet("balanceReport/userId={userId}/startDate={startDate}/endDate={endDate}")]
    public async Task<ActionResult<SummaryReportDTO>> GetBalanceReportByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        try {
            SummaryReportDTO balanceReport = await _budgetReportService.GetSummaryReportByDateRangeAsync(userId, startDate, endDate);
            if(balanceReport == null)
            {
                return NotFound("No balances found for the given date range and User.");
            }
            return Ok(balanceReport);
        } 
        catch(Exception ex) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving balances: {ex.Message}");
        }
    }
}


