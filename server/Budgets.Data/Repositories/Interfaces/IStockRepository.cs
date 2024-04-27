using Microsoft.EntityFrameworkCore;
using Budgets.Models;

namespace Budgets.Data
{
    public interface IStockRepository
    {
        // public Stock AddStock(Stock stock);

        public IEnumerable<Stock> GetAllStocksForUser(int UserId);

        public Stock? GetStockById(int Id);

        public Stock AddStock(Stock stock);

        public Stock UpdateStock(Stock stock);

        public Stock DeleteStock(int Id);

    }
}