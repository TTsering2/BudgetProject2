using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;
using System.Collections.Generic;
using Budgets.DTOs;


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
        IEnumerable<StockDTO> stocks = [
            new StockDTO
            { 
                CompanyName = "Apple", 
                Price = 100, 
                Quantity = 10
            },
            new StockDTO
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
        IEnumerable<StockDTO> stock = [
            
            new StockDTO {CompanyName = "Apple", Price = 100, Quantity = 10 },
            new StockDTO {CompanyName = "Google", Price = 200, Quantity = 20 },
            new StockDTO {CompanyName = "Nvidia", Price = 300, Quantity = 30 }
    
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
    public async Task AddStock_ReturnsStock(){
        // Arrange
        StockCreateDTO stockDTO = new StockCreateDTO(){ UserId = 1, CompanyName = "Apple", Price = 100, Quantity = 10};

        Stock stock = new Stock()
        {
            UserId = stockDTO.UserId,
            CompanyName = stockDTO.CompanyName,
            Price = stockDTO.Price,
            Quantity = stockDTO.Quantity
        };
        
       _stockRepository.Setup(s => s.AddStock(stockDTO));

        // Act
        await _stockServices.AddStock(stockDTO);

        // Assert
        _stockRepository.Verify(s => s
        .AddStock(It.Is<StockCreateDTO>(s => s
        .UserId == stockDTO.UserId 
        && s.CompanyName == stockDTO.CompanyName 
        && s.Price == stockDTO.Price 
        && s.Quantity == stockDTO.Quantity)),
        Times.Once);
    }
    

    //Test for addstock with invalid and valid values, to ensure method is only adding valid values

    [Theory]
    [InlineData("Apple", 100, 10, true)]
    [InlineData("Invalid!", 100, 10, false)]
    [InlineData("Apple", -1, 10, false)]
    [InlineData("Apple", 100, -1, false)]


    public async Task AddStock_ValidStock_AddsStock(string companyName, double price, int quantity, bool isValid){
        // Arrange
        var stockCreateDTO = new StockCreateDTO { 

            CompanyName = companyName, 
            Price = price, 
            Quantity = quantity 
        };

        if (isValid)
        {
             // Map StockCreateDTO to Stock
            var stock = new Stock
            {
                CompanyName = stockCreateDTO.CompanyName,
                Price = stockCreateDTO.Price,
                Quantity = stockCreateDTO.Quantity
            };
            _stockRepository.Setup(repo => repo.AddStock(stockCreateDTO));
        }

        // Act
        await _stockServices.AddStock(stockCreateDTO);

        // Assert
        if (isValid)
        {
            _stockRepository.Verify(r => r.AddStock(stockCreateDTO), Times.Once);
        }
        else
        {
            _stockRepository.Verify(r => r.AddStock(stockCreateDTO), Times.Never);
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
        int stockId = 1;
        var stockUpdateDTO = new StockUpdateDTO 
        { 
            CompanyName = companyName, 
            Price = price, 
            Quantity = quantity
        };
        
        var stock = new Stock {
            Id = stockId, 
            CompanyName = companyName, 
            Price = price, 
            Quantity = quantity     
        };


        if (shouldUpdate)
        {
              _stockRepository.Setup(repo => repo.UpdateStock(stockId, stockUpdateDTO)).Returns(stock);
        }

        // Act
        Stock result = _stockServices.UpdateStock(stockId, stockUpdateDTO);

        // Assert
        if (shouldUpdate)
        {
            Assert.Equal(stock, result);
            _stockRepository.Verify(repo => repo.UpdateStock(stockId, stockUpdateDTO), Times.Once);
        }
        else
        {
            Assert.Null(result);
            _stockRepository.Verify(repo => repo.UpdateStock(stockId, stockUpdateDTO), Times.Never);
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

    