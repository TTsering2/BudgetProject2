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
<<<<<<< HEAD
    private readonly IIncomeService _service;

    public IncomeController(IIncomeService service)
    {
        _service = service;
=======
    private readonly IncomeService _incomeService;

    public IncomeController(IncomeService incomeService)
    {
        this._incomeService = incomeService;
    }


    //get all incomes for a user
    //GET: api/expense/userId={userId}
    [HttpGet("userId = {userId}")]
    public async Task<ActionResult<IncomeDTO>> GetAllIncomeByUserId(int incomeId)
    {
        try
        {
            IEnumerable<IncomeDTO> incomes = await _incomeService.GetIncomeByUserIdAsync(incomeId);
            if(incomes ==null)
            {
                return NotFound("No income found for the given user. ");
            }
            return Ok(incomes);
                
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving income: {ex.Message}");
        }
>>>>>>> 5602e33 (fixed service, DTO)
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
























    [HttpPost]
    public async Task<ActionResult> createIncome(IncomeCreateDTO data){
        try{
            IncomeDTO creatingIncome = await _service.AddItemAsync(data);
            return CreatedAtAction(nameof(getItemById), new{ id = creatingIncome.Id, creatingIncome});

        }catch(Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating income: {ex.Message}");
        }

    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> updateIncome(int id, IncomeUpdateDTO data){
        try{
            await _service.UpdateItemAsync(id, data);
            return NoContent();
        }
        catch(Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating income: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteIncome(int id){
        try{
            await _service.DeleteItemsAsync(id);
            return NoContent();
        }catch(Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting income: {ex.Message}");
        }
    }

}







