public class StockCreateDTO
{
    public string CompanyName { get; set; }
    public string TickerSymbol { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}