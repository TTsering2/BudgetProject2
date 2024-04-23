namespace Budgets.Models;

public class Expense 
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}