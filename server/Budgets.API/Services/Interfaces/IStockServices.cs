using Budgets.Models;
using Budgets.Data;
using Budgets.DTOs;


namespace Budgets.Services;
public interface IStockServices
{

    IEnumerable<StockDTO> GetAllStocksForUser(int UserId);
    
    Stock? GetStockById (int Id);

    Task<StockCreateDTO> AddStock(StockCreateDTO stock);

    Task UpdateStock(int stockId, StockUpdateDTO stock);
    
    Stock DeleteStock(int Id);
}