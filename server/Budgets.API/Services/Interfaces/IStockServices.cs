using Budgets.Models;
using Budgets.Data;


namespace Budgets.Services;
public interface IStockServices
{

    IEnumerable<Stock> GetAllStocksForUser(int UserId);
    
    Stock? GetStockById (int Id);

    Stock AddStock(Stock stock);

    Stock UpdateStock(Stock stock);
    
    Stock DeleteStock(int Id);
}