namespace Budgets.DTOs;
public class IncomeReportDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Dictionary<string, decimal> IncomeByCategory { get; set; }
    public IEnumerable<IncomeDTO> Top3Incomes { get; set; }

}