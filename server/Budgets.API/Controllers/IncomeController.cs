using Microsoft. AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;
using Budgets.DTOs;



namespace Budgets.Controller;


[Route("api/[controller]")]
[ApiController]
public class IncomeController : ControllerBase{
    private readonly IIncomeService _incomeService;

    public IncomeController(IIncomeService incomeservice)
    {
        _incomeService = incomeservice;
    }


    //get all expenses for a user
    //GET: api/expense/userId={userId}
    [HttpGet("userId={userId}")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetAllIncomeByUserId(int userId)
    {
        try 
        {
            IEnumerable<IncomeDTO> incomes = await _incomeService.GetIncomeByUserIdAsync(userId);
            if(incomes == null || !incomes.Any())
            {
                return NotFound("No incomes found for the given User.");
            }
            return Ok(incomes);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving incomes: {ex.Message}");
        }
    }


     //get an income by a user and income id
    //GET api/income/userId={userId}/incomeId={incomeId}
    [HttpGet("userId={userId}/incomeId={incomeId}")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetIncomeByUserIdAndIncomeId(int userId, int incomeId)
    {    
        try{
            IncomeDTO incomes = await _incomeService.GetIncomeByUserIdAndIncomeIdAsync(userId,incomeId);
            if(incomes == null)
            {
                return NotFound("Expense not found");
            }
            return Ok(incomes); 
        }catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving income: {ex.Message}");
        }
    }


    //get an income by a user and income type
    //GET api/income/{userId}/{incomeType}
    [HttpGet("{userId}/{incomeType}")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetByUserIdAndIncomeType(int userId, string incomeType)
    {
        try
        {
            IEnumerable<IncomeDTO> incomes = await _incomeService.GetIncomeByUserIdAndIncomeTypeAsync(userId, incomeType);
            if(incomes == null || !incomes.Any())
            {
                return NotFound("No incomes found for the given expense type and User.");
            }
            return Ok(incomes);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving incomes: {ex.Message}");
        }
    }


    //add an income
    //POST api/income
    [HttpPost]
    public async Task<ActionResult<Income>> AddAnIncome([FromBody]IncomeCreateDTO income)
    {
        try{
            await _incomeService.AddAnIncomeAsync(income);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding income: {ex.Message}");
        }
    }

    //delete an income
    //DELETE api/income/incomeeId={incomeId}
    [HttpDelete("incomeId={incomeId}")]
    public async Task<ActionResult> DeleteAnExpense(int incomeId)
    {
        try
        {
            await _incomeService.DeleteAnIncomeAsync(incomeId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting expense: {ex.Message}");
        }
    }

    //update an income
    //PATCH api/income/{incomeId}
    [HttpPatch("{incomeID}")]
    public async Task<ActionResult> UpdateAnExpense(int incomeId, IncomeUpdateDTO income)
    {
        try
        {
            await _incomeService.UpdateAnIncomeAsync(incomeId, income);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating income: {ex.Message}");
        }
    }


    //Get all incomes by a user and date range
    //GET api/income/userId={userId}/startDate={startDate}/endDate={endDate}
    [HttpGet("userId={userId}/startDate={startDate}/endDate={endDate}")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetIncomeByUserIdAndDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        try
        {
            IEnumerable<IncomeDTO> incomes = await _incomeService.GetIncomeByUserIdAndDateRangeAsync(userId, startDate, endDate);
            if(incomes == null || !incomes.Any())
            {
                return NotFound("No incomes found for the given date range and User.");
            }
            return Ok(incomes);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving incomes: {ex.Message}");
        }
    }

}







