using Microsoft. AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

    public IEnumerable<Stock> GetAllStocksForUser(int UserId) {

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
    public Stock AddStock(Stock stock) {

        if(StockValidator.ValidateAll(stock.CompanyName, stock.Price, stock.Quantity)) {
            return _stockRepository.AddStock(stock);    
        }
        else{
            return null;
        }
    }


    // Update a Stock
    public Stock UpdateStock(Stock stock) {
        if(StockValidator.ValidateAll(stock.CompanyName, stock.Price, stock.Quantity)){
            return _stockRepository.UpdateStock(stock);
        }
        else{
            return null;
        }
    }


    // Delete a Stock
    public Stock DeleteStock(int Id) {
        Stock deletedStock = _stockRepository.DeleteStock(Id);
        return deletedStock;
    }
}

