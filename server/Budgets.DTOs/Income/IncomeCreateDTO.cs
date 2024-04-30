namespace Budgets.DTOs;


public class IncomeCreateDTO
{   
    public string Title { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public int UserId { get; set; } 


    
}