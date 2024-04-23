namespace Budgets.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public IEnumerable<Expense> Expenses { get; set; }
    public IEnumerable<Income> Incomes { get; set; }
    public IEnumerable<Stock> Stocks { get; set; }
}
