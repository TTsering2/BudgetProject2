namespace Budgets.DTOs;
public class ExpenseReportDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Dictionary<string, decimal> ExpensesByCategory { get; set; }
    public IEnumerable<ExpenseDTO> Top3Expenses { get; set; }

}