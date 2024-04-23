namespace Budgets.Models;

public class Stock
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string TickerSymbol { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}