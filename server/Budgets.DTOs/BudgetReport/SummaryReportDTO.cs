namespace Budgets.DTOs;
public class SummaryReportDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal NetValue { get; set; }
}