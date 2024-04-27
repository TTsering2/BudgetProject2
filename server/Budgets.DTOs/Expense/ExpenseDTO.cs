namespace Budgets.DTOs

public class ExpenseDTO
{    
    public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Username { get; set; }
}
