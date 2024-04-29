 namespace Budgets.Tests;
 using Moq;
 using Xunit;
 using Budgets.DTOs;
 using Budgets.Data;
 using Budgets.Services;
using Microsoft.Extensions.ObjectPool;
using System.Reflection.Metadata;



public class IncomesServiceTests
{   

     private readonly Mock<IIncomeRepository> _mockRepo;
     private readonly IncomeService _incomeServices;

     public IncomesServiceTests(){
         _mockRepo = new Mock<IIncomeRepository>();
         _incomeServices = new IncomeService(_mockRepo.Object);
     }


    // Making sure UserId is valid in output their income information
     [Fact]
     public async Task GetIncomeByUserId_Return_WhenUserIdIsValid(){
        //Arrange
        int userId = 1;
        var expectIncome = new List<IncomeDTO>
        {
            new IncomeDTO{ Id = 1, Title = "Salary", Type = " Monthly", Amount = 2000, Date = DateTime.Now, Username = "User1"},
            new IncomeDTO{ Id = 2, Title = "Bonus", Type = " one-time", Amount = 1000, Date = DateTime.Now.AddDays(-30), Username = "User1"}

        };    

        _mockRepo.Setup(x => x.GetIncomeByUserIdAsync(userId)).ReturnsAsync(expectIncome);


        //Act
        var actualIncome = await _incomeServices.GetIncomeByUserIdAsync(userId);

        //Assert
        Assert.Equal(expectIncome,actualIncome);
    }
    
        [Fact]
        public async Task GetIncomeByUserIdAndIncomeTypeAsync_Return_WhenValidUserIdAndIncomeType()
        {
            // Arrange
            int userId = 1;
            string incomeType = "Monthly";

            var expectedIncomes = new List<IncomeDTO>
            {
                new IncomeDTO { Id = 1, Title = "Salary", Type = "Monthly", Amount = 2000, Date = DateTime.Now, Username = "user1" },
                new IncomeDTO { Id = 2, Title = "Rent", Type = "Monthly", Amount = 1500, Date = DateTime.Now.AddDays(-7), Username = "user1" }
            };
            _mockRepo.Setup(repo => repo.GetIncomeByUserIdAndIncomeTypeAsync(userId, incomeType)).ReturnsAsync(expectedIncomes);


            // Act
            var actualIncomes = await _incomeServices.GetIncomeByUserIdAndIncomeTypeAsync(userId, incomeType);

            // Assert
            Assert.Equal(expectedIncomes, actualIncomes);
        }


        [Fact]
        public async Task AddAnIncomeAsync_ShouldAddIncome_WhenValidIncomeCreateDTO()
        {
            // Arrange
            var newIncomeDTO = new IncomeCreateDTO
            {
                Title = "Bill",
                Type = "Monthly",
                Amount = 340,
                Date = DateTime.Now,
                UserId = 1
            };

            // Act
            await _incomeServices.AddAnIncomeAsync(newIncomeDTO);

            // Assert
            _mockRepo.Verify(repo => repo.AddAnIncomeAsync(newIncomeDTO), Times.Once);
        }


        [Fact]
        public async Task DeleteAnIncomeAsync_ShouldDelete_WhenValidIncomeId()
        {
            // Arrange
            int incomeId = 1;
            // Act
            await _incomeServices.DeleteAnIncomeAsync(incomeId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAnIncomeAsync(incomeId), Times.Once);
        }


        [Fact]
        public async Task UpdateAnIncomeAsync_ShouldUpdate_WhenValidIncomeIdAndIncomeUpdateDTO()
        {
            // Arrange
            int incomeId = 1;

            var updateDTO = new IncomeUpdateDTO
            {
                Title = "Updated* Salary",
                Type = "Updated* Monthly",
                Amount = 2500,
                Date = DateTime.Now.AddDays(1)
            };

            // Act
            await _incomeServices.UpdateAnIncomeAsync(incomeId, updateDTO);

            // Assert
            _mockRepo.Verify(repo => repo.UpdatAnIncomeeAsync(incomeId, updateDTO), Times.Once);
        }

          [Fact]
        public async Task GetIncomeByUserIdAndDateRangeAsync_ShouldReturn_WhenValidUserIdAndDateRange()
        {
            // Arrange
            int userId = 1;
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;
//DateTime.Now.AddDays(-30) targetting the beginning of the month
            var expectedIncomes = new List<IncomeDTO>
            {
                new IncomeDTO { Id = 1, Title = "Bills", Type = "Monthly", Amount = 5000, Date = DateTime.Now, Username = "user1" },
                new IncomeDTO { Id = 2, Title = "groceries", Type = "weekly", Amount = 1000, Date = DateTime.Now.AddDays(-30), Username = "user1" }
            };

            
            _mockRepo.Setup(repo => repo.GetIncomeByUserIdAndDateRangeAsync(userId, startDate, endDate)).ReturnsAsync(expectedIncomes);

            // Act
            var actualIncomes = await _incomeServices.GetIncomeByUserIdAndDateRangeAsync(userId, startDate, endDate);

            // Assert
            Assert.Equal(expectedIncomes, actualIncomes);
        }

}
