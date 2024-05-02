
using Budgets.Models;
using Budgets.Data;
using Budgets.DTOs;

namespace Budgets.Services;

public class StockServices : IStockServices
{
    private readonly IStockRepository _stockRepository;
    private readonly ILogger<StockServices> _logger;

    public StockServices(IStockRepository stockRepository, ILogger<StockServices> logger)
    {
        _stockRepository = stockRepository;
        _logger = logger;
    }



    // Get all Stocks for a given User

    public IEnumerable<StockDTO> GetAllStocksForUser(int UserId) {

        try{
            _logger.LogInformation($"Getting all Stocks for User: {UserId}");
            return _stockRepository.GetAllStocksForUser(UserId);
        }

        catch(Exception ex){  
            _logger.LogError($"Failed to get Stocks: {ex}");
            throw;
        }
    }



    // Get a stock by Id
    public Stock? GetStockById (int Id) {
        try{
            return _stockRepository.GetStockById(Id);
        }
        catch(Exception ex){
            _logger.LogError($"Failed to get Stock: {ex}");
            throw;
        }
    }


    // Add a Stock
    public async Task<StockCreateDTO?> AddStock(StockCreateDTO stock) {

        if(StockValidator.ValidateAll(stock.CompanyName, stock.Price, stock.Quantity)) {
            await _stockRepository.AddStock(stock);    
            return stock; // Return the added stock
        }
        else{
            return default; // Return null as default
        }
    }


    // Update a Stock

    public async Task UpdateStock(int stockId, StockUpdateDTO stock) {
        double price = stock.Price ?? default(double);
        int quantity = stock.Quantity ?? default(int);
        try {
            if (StockValidator.ValidateAll(stock.CompanyName, price, quantity)) {
                await _stockRepository.UpdateStock(stockId, stock);
            }
        }
        catch (Exception ex) {
            _logger.LogError(ex, "Failed to update Stock: {StockId}", stockId);
        }
    }


    // Delete a Stock
    public Stock DeleteStock(int Id) {
        
        Stock deletedStock = _stockRepository.DeleteStock(Id);
        return deletedStock;
    }

}


