namespace Budgets.DTOs;

public class ExpenseUpdateDTO
{
    public string? Title { get; set; }
    public string? Type { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Date { get; set; }
}