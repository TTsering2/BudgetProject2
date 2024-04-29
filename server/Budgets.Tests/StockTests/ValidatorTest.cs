// using Xunit;
// using Moq;
// using Microsoft.Extensions.Logging;
// using Budgets.Models;
// using Budgets.Services;
// using Budgets.Data;

// namespace Budgets.Tests;

// public class ValidatorTests
// {
//     [Theory]
//     [InlineData("Apple", true)]
//     [InlineData("Google!", false)]
//     [InlineData("", false)]
//     [InlineData(null, false)]
//     public void ValidateName_ReturnsExpectedResult(string companyName, bool expectedResult)
//     {
//         // Act
//         var result = StockValidator.ValidateName(companyName);

//         // Assert
//         Assert.Equal(expectedResult, result);
//     }

//     [Theory]
//     [InlineData(100, true)]
//     [InlineData(-1, false)]
//     public void ValidatePrice_ReturnsExpectedResult(double price, bool expectedResult)
//     {
//         // Act
//         var result = StockValidator.ValidatePrice(price);

//         // Assert
//         Assert.Equal(expectedResult, result);
//     }

//     [Theory]
//     [InlineData(10, true)]
//     [InlineData(-1, false)]
//     public void ValidateQuantity_ReturnsExpectedResult(int quantity, bool expectedResult)
//     {
//         // Act
//         var result = StockValidator.ValidateQuantity(quantity);

//         // Assert
//         Assert.Equal(expectedResult, result);
//     }

//     [Theory]
//     [InlineData("Apple", 100, 10, true)]
//     [InlineData("Google!", 100, 10, false)]
//     [InlineData("Apple", -1, 10, false)]
//     [InlineData("Apple", 100, -1, false)]
//     public void ValidateAll_ReturnsExpectedResult(string companyName, double price, int quantity, bool expectedResult)
//     {
//         // Act
//         var result = StockValidator.ValidateAll(companyName, price, quantity);

//         // Assert
//         Assert.Equal(expectedResult, result);
//     }
// }

// //