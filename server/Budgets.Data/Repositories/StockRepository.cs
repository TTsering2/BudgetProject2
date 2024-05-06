using Microsoft.EntityFrameworkCore;
using Budgets.Models;
using Budgets.Data;
using Budgets.DTOs;

namespace Budgets.Data;


public class StockRepository : IStockRepository
{
    private readonly BudgetsDbContext _context;

    public StockRepository(BudgetsDbContext context){
        _context = context;
    }



    // Get all Stocks for a given User
    public IEnumerable<StockDTO> GetAllStocksForUser(int UserId) {
        IEnumerable<StockDTO> stocks = _context.Stocks
        .Where(s => s.UserId == UserId)
        .Include(s => s.User)
        .Select(s => new StockDTO
        {
            Id = s.Id,
            CompanyName = s.CompanyName,
            Price = s.Price,
            Quantity = s.Quantity,
            UserId = s.UserId,
        })
        .ToList();

        return stocks;
    }
    
    

    //Get stock by Id
    public Stock? GetStockById(int Id) {
        return _context.Stocks.Find(Id);
    }


    // Add a Stock
    public async Task AddStock(StockCreateDTO stock) {

        Stock newStock = new Stock {
            CompanyName = stock.CompanyName,
            TickerSymbol = stock.TickerSymbol,
            Price = stock.Price,
            Quantity = stock.Quantity,
            UserId = stock.UserId
        };
        _context.Stocks.Add(newStock);
        _context.SaveChanges();
        Console.WriteLine("Stock added successfully.");
    }

    // Update a Stock
    public async Task<Stock> UpdateStock(int stockId, StockUpdateDTO stock) {
        // Find stock by Id
        Stock oldStock = await _context.Stocks
            .Include(s => s.User) // Include user info
            .FirstOrDefaultAsync(s => s.Id == stockId);

        if (oldStock == null) {
            throw new Exception($"Stock with Id {stockId} not found.");
        } else {
            // Check any changes from old to new
            oldStock.CompanyName = stock.CompanyName ?? oldStock.CompanyName;
            oldStock.TickerSymbol = stock.TickerSymbol ?? oldStock.TickerSymbol;
            oldStock.Price = stock.Price ?? oldStock.Price;
            oldStock.Quantity = stock.Quantity ?? oldStock.Quantity;
        }

        await _context.SaveChangesAsync();
        return oldStock;
    }


    // Delete a Stock
    public Stock DeleteStock(int Id) {
        Stock deletedStock = GetStockById(Id);
        try{
            if(deletedStock != null){
                _context.Stocks.Remove(deletedStock);
                _context.SaveChanges();
                return deletedStock;
            }
        }
        catch(Exception ex){
            Console.WriteLine($"Failed to delete Stock: {ex}");
            throw;
        }
        
        return deletedStock;
    }
}
