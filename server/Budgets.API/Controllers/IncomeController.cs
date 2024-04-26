using Budgets.Data;
using Budgets.Models;
using Budgets.Services;
using Budgets.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;
using Microsoft.Identity.Client;



namespace Budgets.Controller;


[Route("api/[controller]")]
[ApiController]
public class IncomeController : ControllerBase{
    private readonly IncomeService _service;

    public IncomeController(IncomeService service)
    {
        this._service = service;
    }



    [HttpGet("id={id}")]
    public async Task<ActionResult<IncomeDTO>> getItemById(int id){
        try{
            IncomeDTO income = await _service.GetItemByIdAsync(id);

            if(income ==null){
                return NotFound();
            }
                return income;
            }catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving income: {ex.Message}");
            }
        }



        //get ALL incomes
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> getAllIncome(){    
        try{
            IEnumerable<IncomeDTO> incomes = await _service.ListItemsAsync();
            return Ok(incomes); 
        }catch(Exception ex){
        return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving income: {ex.Message}");
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







