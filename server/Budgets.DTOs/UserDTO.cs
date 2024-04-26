using Budgets.Models;
namespace Budgets.DTOs;

public class UserDTO
{   
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public IEnumerable<Expense> Expenses { get; set; }
    public IEnumerable<Income> Incomes { get; set; }
    public IEnumerable<Stock> Stocks { get; set; }
}
