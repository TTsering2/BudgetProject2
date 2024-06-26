using Microsoft. AspNetCore.Mvc;
using Budgets.Models;
using Budgets.Services;
using Budgets.DTOs;


namespace Budgets.Controller;

[Route("api/[controller]")]
[ApiController]

public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    
    //get all expenses for a user
    //GET: api/expense/userId={userId}
    [HttpGet("userId={userId}")]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetAllExpensesByUserId(int userId)
    {
        try 
        {
            IEnumerable<ExpenseDTO> expenses = await _expenseService.GetExpensesByUserIdAsync(userId);
            if(expenses == null || !expenses.Any())
            {
                return NotFound("No Expenses found for the given User.");
            }
            return Ok(expenses);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving expenses: {ex.Message}");
        }
    }

    //get an expense by a user and expense id
    //GET api/expense/userId={userId}/expenseId={expenseId}
    [HttpGet("userId={userId}/expenseId={expenseId}")]
    public async Task<ActionResult<ExpenseDTO>> GetExpenseByUserIdAndExpenseId(int userId, int expenseId)
    {
        try
        {
            ExpenseDTO expense = await _expenseService.GetExpenseByUserIdAndExpenseIdAsync(userId, expenseId);
            if(expense == null)
            {
                return NotFound("Expense not found.");
            }
            return Ok(expense);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving expense: {ex.Message}");
        }
    }

    //get an expense by a user and expense type
    //GET api/expense/{userId}/{expenseType}
    [HttpGet("{userId}/{expenseType}")]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetByUserIdAndExpenseType(int userId, string expenseType)
    {
        try
        {
            IEnumerable<ExpenseDTO> expenses = await _expenseService.GetExpensesByUserIdAndExpenseTypeAsync(userId, expenseType);
            if(expenses == null || !expenses.Any())
            {
                return NotFound("No expenses found for the given expense type and User.");
            }
            return Ok(expenses);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving expenses: {ex.Message}");
        }
    }

    //add an expense
    //POST api/expense
    [HttpPost]
    public async Task<ActionResult<Expense>> AddAnExpense([FromBody]ExpenseCreateDTO expense)
    {
        try{
            await _expenseService.AddAnExpenseAsync(expense);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding expense: {ex.Message}");
        }
    }
    
    //delete an expense
    //DELETE api/expense/expenseId={expenseId}
    [HttpDelete("expenseId={expenseId}")]
    public async Task<ActionResult> DeleteAnExpense(int expenseId)
    {
        try
        {
            await _expenseService.DeleteAnExpenseAsync(expenseId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting expense: {ex.Message}");
        }
    }

    //update an expense
    //PATCH api/expense/{expenseId}
    [HttpPatch("{expenseId}")]
    public async Task<ActionResult> UpdateAnExpense(int expenseId, ExpenseUpdateDTO expense)
    {
        try
        {
            await _expenseService.UpdateAnExpenseAsync(expenseId, expense);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating expense: {ex.Message}");
        }
    }

    //Get all expenses by a user and date range
    //GET api/expense/userId={userId}/startDate={startDate}/endDate={endDate}
    [HttpGet("userId={userId}/startDate={startDate}/endDate={endDate}")]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetExpensesByUserIdAndDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        try
        {
            IEnumerable<ExpenseDTO> expenses = await _expenseService.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate);
            if(expenses == null || !expenses.Any())
            {
                return NotFound("No expenses found for the given date range and User.");
            }
            return Ok(expenses);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving expenses: {ex.Message}");
        }
    }
}