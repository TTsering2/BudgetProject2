// using Xunit;
// using Moq;
// using Budgets.Models;
// using Budgets.Services;
// using Budgets.Data;
// using Budget.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Budgets.DTOs;


// public class StockControllerTests
// {
//     private readonly Mock<IStockRepository> _stockRepository;
//     private readonly Mock<IStockServices> _stockServices;
//     private readonly StockController _stockController;

//     public StockControllerTests()
//     {
//         _stockRepository = new Mock<IStockRepository>();
//         _stockServices = new Mock<IStockServices>();
//         _stockController = new StockController(_stockServices.Object);
//     }

//     [Fact]
//     public void GetAllStocksForUser_ValidUserId_ReturnsOkResult()
//     {
//         // Arrange
//         var stocks = new List<StockDTO> { 
//             new StockDTO { 
//                 Id = 1,
//                 CompanyName = "Apple",
//                 TickerSymbol = "AAPL",
//                 Price = 100, 
//                 Quantity = 10, 
//                 Date = DateTime.Now,
//                 UserId = 1
//             } 
//         };
//         _stockServices.Setup(services => services.GetAllStocksForUser(It.IsAny<int>())).Returns(stocks);

//         // Act
//         var result = _stockController.GetAllStocksForUser(1);

//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result.Result);
//         var returnStocks = Assert.IsType<List<StockDTO>>(okResult.Value);
//         Assert.Equal(stocks, returnStocks);
//     }

//     [Fact]
//     public void GetStockById_ValidId_ReturnsOkResult()
//     {
//         // Arrange
//         var stock = new Stock { Id = 1, CompanyName = "Apple", Price = 100, Quantity = 10 };
//         _stockServices.Setup(services => services.GetStockById(It.IsAny<int>())).Returns(stock);

//         // Act
//         var result = _stockController.GetStockById(1);

//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result.Result);
//         var returnStock = Assert.IsType<Stock>(okResult.Value);
//         Assert.Equal(stock, returnStock);
//     }

    
// }