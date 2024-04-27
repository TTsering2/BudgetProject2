namespace Budgets.DTOs
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TickerSymbol { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}