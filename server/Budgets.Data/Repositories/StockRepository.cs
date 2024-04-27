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
    public IEnumerable<Stock> GetAllStocksForUser(int UserId) {
        return _context.Stocks.Where(s => s.UserId == UserId).ToList();
    }
    
    

    //Get stock by Id
    public Stock? GetStockById(int Id) {
        return _context.Stocks.Find(Id);
    }


    // Add a Stock
    public Stock AddStock(Stock stock) {
        _context.Stocks.Add(stock);
        _context.SaveChanges();
        return stock;
    }

    // Update a Stock
    public Stock UpdateStock(Stock stock) {
        _context.Stocks.Update(stock);
        _context.SaveChanges();
        return stock;
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
