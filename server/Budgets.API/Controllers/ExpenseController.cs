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

public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    

}