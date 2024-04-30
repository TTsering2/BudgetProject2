using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;
using System.Collections.Generic;


namespace Budgets.Tests;

public class StockServicesTests{
    private readonly Mock<IStockRepository> _stockRepository;
    private readonly Mock<ILogger<StockServices>> _logger;
    private readonly StockServices _stockServices;

    public StockServicesTests()
    {
        _stockRepository = new Mock<IStockRepository>();
        _logger = new Mock<ILogger<StockServices>>();
        _stockServices = new StockServices(_stockRepository.Object, _logger.Object);
    }

    [Fact]
    public void GetAllStocksForUser_ReturnsStocks(){

        // Arrange
        int userId = 1;
        IEnumerable<Stock> stocks = [
            new Stock
            { 
                CompanyName = "Apple", 
                Price = 100, 
                Quantity = 10
            },
            new Stock
            {
                CompanyName = "Google",
                Price = 200, 
                Quantity = 20
            }
        ];
        _stockRepository.Setup(s => s.GetAllStocksForUser(userId)).Returns(stocks);

        // Act
        var result = _stockServices.GetAllStocksForUser(userId);

        // Assert
        Assert.Equal(stocks, result);
    }

    [Fact]
    public void GetAllStocksForUser_ReturnsAllStocks()
    {
        // Arrange
        int UserId = 1;
        IEnumerable<Stock> stock = [
            
            new Stock {CompanyName = "Apple", Price = 100, Quantity = 10 },
            new Stock {CompanyName = "Google", Price = 200, Quantity = 20 },
            new Stock {CompanyName = "Nvidia", Price = 300, Quantity = 30 }
    
        ];
        _stockRepository.Setup(repo => repo.GetAllStocksForUser(UserId)).Returns(stock);

        // Act
        var result = _stockServices.GetAllStocksForUser(UserId);

        // Assert
        Assert.Equal(3, result.Count());
        _stockRepository.Verify(repo => repo.GetAllStocksForUser(UserId), Times.Exactly(1));
    }

    //Test for GetStockById

    [Fact]
    public void GetStockById_ReturnsStock(){
        // Arrange
        int stockId = 1;
        Stock stock = new Stock(){Id = 1, UserId = 1, CompanyName = "Apple", Price = 100, Quantity = 10};
        _stockRepository.Setup(s => s.GetStockById(stockId)).Returns(stock);

        // Act
        var result = _stockServices.GetStockById(stockId);

        // Assert
        Assert.Equal(stock, result);
    }


    //Test for AddStock, to ensure the method iw adding a stock

    [Fact]
    public void AddStock_ReturnsStock(){
        // Arrange
        Stock stock = new Stock(){Id = 1, UserId = 1, CompanyName = "Apple", Price = 100, Quantity = 10};
        _stockRepository.Setup(s => s.AddStock(stock)).Returns(stock);

        // Act
        var result = _stockServices.AddStock(stock);

        // Assert
        Assert.Equal(stock, result);
    }

    //Test for addstock with invalid and valid values, to ensure method is only adding valid values

    [Theory]
    [InlineData("Apple", 100, 10, true)]
    [InlineData("Invalid!", 100, 10, false)]
    [InlineData("Apple", -1, 10, false)]
    [InlineData("Apple", 100, -1, false)]


    public void AddStock_ValidStock_AddsStock(string companyName, double price, int quantity, bool isValid){
        // Arrange
        var stock = new Stock { 
            Id = 1,
            CompanyName = companyName, 
            Price = price, 
            Quantity = quantity 
        };

        if (isValid)
        {
            _stockRepository.Setup(repo => repo.AddStock(stock)).Returns(stock);
        }

        // Act
        Stock addedStock = _stockServices.AddStock(stock);

        // Assert
        if (isValid)
        {
            Assert.Equal(stock, addedStock);
            _stockRepository.Verify(r => r.AddStock(stock), Times.Once);
        }
        else
        {
            Assert.Null(addedStock);
            _stockRepository.Verify(r => r.AddStock(stock), Times.Never);
        }
    }


    //Test for UpdateStock, to ensure the method is updating a stock with valid values only

     [Theory]
    [InlineData("Apple", 100, 10, true)]
    [InlineData("Invalid!", 100, 10, false)]
    [InlineData("Apple", -1, 10, false)]
    [InlineData("Apple", 100, -1, false)]
    public void UpdateStock_Test(string companyName, double price, int quantity, bool shouldUpdate)
    {
        // Arrange
        var stock = new Stock { Id = 1, CompanyName = companyName, Price = price, Quantity = quantity };

        if (shouldUpdate)
        {
            _stockRepository.Setup(repo => repo.UpdateStock(stock)).Returns(stock);
        }

        // Act
        var result = _stockServices.UpdateStock(stock);

        // Assert
        if (shouldUpdate)
        {
            Assert.Equal(stock, result);
            _stockRepository.Verify(repo => repo.UpdateStock(stock), Times.Once);
        }
        else
        {
            Assert.Null(result);
            _stockRepository.Verify(repo => repo.UpdateStock(stock), Times.Never);
        }
    }
    
    [Fact]
    public void DeleteStock_ValidId_ReturnsDeletedStock()
    {
        // Arrange
        var stock = new Stock { Id = 1, CompanyName = "Apple", Price = 100, Quantity = 10 };
        _stockRepository.Setup(repo => repo.DeleteStock(stock.Id)).Returns(stock);

        // Act
        var result = _stockServices.DeleteStock(stock.Id);

        // Assert
        Assert.Equal(stock, result);
        _stockRepository.Verify(repo => repo.DeleteStock(stock.Id), Times.Once);
    }
}

    