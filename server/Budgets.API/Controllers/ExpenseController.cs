
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
//using budgettracker.data;
//using Budgets.Data;//
using Budgets.Models;//
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using BudgetProject2;

namespace budgettracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController: Controller
{
    //Inject repo
    //private readonly BudgetRepository repo;
//Inject Service
    private readonly ExpensesService service;

    public ExpenseController(ExpensesService service)
    {
        this.service = service;
    }

    /*---------LIST ALL EXPENSES----------*/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Expense> GetExpenses(){

       return service.ListItems();
    }


    /*---------ADD NEW EXPENSE----------*/

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult  AddExpense(Expense expense){

        Expense result = service.AddItem(expense);
        if(result!= null){
            return CreatedAtAction(nameof(AddExpense), new { id = result.Id }, result);
        }
        else{
            return BadRequest("Could not add new expense");
        }    }

        /*---------UPDATE NEW EXPENSE----------*/

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public ActionResult UpdateExpense(Expense expense){
        Expense result = service.UpdateItem(expense);
            if(result != null){
                return CreatedAtAction(nameof(UpdateExpense), new { id = result.Id }, result);
            }
            else{                    
                return BadRequest("Could not edit the selected income");
            }
    }

    /*---------DELETE NEW EXPENSE----------*/

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> DeleteExpense(Expense expense){
        bool result = service.DeleteItem(expense);
        if(result == true){
            return Ok("The selected expense was deleted");
        }
        else{
            return BadRequest("Could not delete the selected expense");
        }
    }

}
