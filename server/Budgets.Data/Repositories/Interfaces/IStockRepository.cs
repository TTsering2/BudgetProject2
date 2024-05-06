using Microsoft.EntityFrameworkCore;
using Budgets.Models;
using Budgets.DTOs;

namespace Budgets.Data
{
    public interface IStockRepository
    {
        // public Stock AddStock(Stock stock);

        IEnumerable<StockDTO> GetAllStocksForUser(int UserId);

        Stock? GetStockById(int Id);

        Task AddStock(StockCreateDTO stock);

        Task<Stock> UpdateStock(int stockId, StockUpdateDTO stock);

        Stock DeleteStock(int Id);

    }
}