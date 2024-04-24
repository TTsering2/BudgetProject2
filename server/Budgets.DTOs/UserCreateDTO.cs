namespace Budgets.DTOs;
using Budgets.Models;


public class UserCreateDTO
{
    public string Name { get; set; }
    public string Username { get; set; }
    public IEnumerable<Expense> Expenses { get; set; }
    public IEnumerable<Income> Incomes { get; set; }
    public IEnumerable<Stock> Stocks { get; set; }
}