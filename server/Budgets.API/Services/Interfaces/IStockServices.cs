using Budgets.Models;
using Budgets.Data;
using Budgets.DTOs;


namespace Budgets.Services;
public interface IStockServices
{

    IEnumerable<StockDTO> GetAllStocksForUser(int UserId);
    
    Stock? GetStockById (int Id);

    public Task<StockCreateDTO> AddStock(StockCreateDTO stock);

    Stock UpdateStock(int stockId, StockUpdateDTO stock);
    
    Stock DeleteStock(int Id);
}