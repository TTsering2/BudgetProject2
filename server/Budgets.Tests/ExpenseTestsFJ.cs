// using Xunit;
// using Moq;
// using Budgets.Models;
// using Budgets.Services;
// using Budgets.Data;
// using Budgets.DTOs;

// public class ExpenseServiceFJTests
// {
//     private readonly Mock<IExpenseRepository> _expenseRepository;
//     private readonly ExpenseService _expenseService;

//     public ExpenseServiceFJTests()
//     {
//         _expenseRepository = new Mock<IExpenseRepository>();
//         _expenseService = new ExpenseService(_expenseRepository.Object);
//     }


//     // Testing GetExpensesByUserIdAsync
//     [Fact]
//     public async Task GetExpensesByUserIdAsync_ValidUserId_ReturnsExpenses(){
//         //Arrange
//         var expense = new List<ExpenseDTO>
//         {
//             new ExpenseDTO{ Id = 1, Title = "Rent", Type = "Monthly", Amount = 1000, Date = DateTime.Now, Username = "User1"},
//             new ExpenseDTO{ Id = 2, Title = "Groceries", Type = "Weekly", Amount = 200, Date = DateTime.Now.AddDays(-7), Username = "User1"}

//         };

//         _expenseRepository.Setup(r => r.GetExpensesByUserIdAsync(1)).ReturnsAsync(expense);
    
//         //Act
//         var result = await _expenseService.GetExpensesByUserIdAsync(1);

//         //Assert 
//         Assert.Equal(expense, result);
//     }

//     // Testing GetExpenseByUserIdAndExpenseIdAsync  
//     [Theory]
//     [InlineData(1, 1, true)]
//     [InlineData(2, 2, true)]
//     [InlineData(3, 3, true)]
//     [InlineData(-1, 1, false)]
//     [InlineData(1, -1, false)]
//     [InlineData(0, 1, false)]
//     [InlineData(1, 0, false)]
//     public async Task GetExpenseByUserIdAndExpenseIdAsync_WithVariousUserIdAndExpenseId_ReturnsExpectedResult(int userId, int expenseId, bool isValid)
//     {
//         // Arrange
//         var expense = isValid ? new ExpenseDTO { Id = expenseId, Amount = 100, Type = "Food" } : null;
//         _expenseRepository.Setup(repo => repo.GetExpenseByUserIdAndExpenseIdAsync(userId, expenseId)).ReturnsAsync(expense);
    
//         // Act
//         var result = await _expenseService.GetExpenseByUserIdAndExpenseIdAsync(userId, expenseId);
    
//         // Assert
//         if (isValid)
//         {
//             Assert.Equal(expense, result);
//         }
//         else
//         {
//             Assert.Null(result);
//         }
//     }

//     // Testing GetExpensesByUserIdAndExpenseTypeAsync with valid and invalid values


//     [Theory]
//     [InlineData(1, "2022-01-01", "2022-01-31", true)]
//     [InlineData(2, "2022-02-01", "2022-02-28", true)]
//     [InlineData(3, "2023-03-01", "2022-03-31", false)]
//     [InlineData(-1, "2022-01-01", "2022-01-31", false)]
//     [InlineData(1, "2022-02-29", "2022-02-29", false)] 
//     public async Task GetExpensesByUserIdAndDateRangeAsync_WithVariousUserIdAndDates_ReturnsExpectedResult(int userId, string start, string end, bool isValid)
//     {
//         // Arrange
//         DateTime startDate = DateTime.MinValue;
//         DateTime endDate = DateTime.MinValue;
//         var isDateValid = DateTime.TryParse(start, out startDate) && DateTime.TryParse(end, out endDate);
//         var expenses = isValid && isDateValid ? new List<ExpenseDTO> { new ExpenseDTO { Id = 1, Amount = 100, Type = "Food" } } : null;
//         _expenseRepository.Setup(repo => repo.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate)).ReturnsAsync(expenses);
    
//         // Act
//         var result = await _expenseService.GetExpensesByUserIdAndDateRangeAsync(userId, startDate, endDate);
    
//         // Assert
//         if (isValid && isDateValid)
//         {
//             Assert.Equal(expenses, result);
//         }
//         else
//         {
//             Assert.Null(result);
//         }
//     }

//     // Testing AddAnExpenseAsync with valid and invalid values
//     [Theory]
//     [InlineData("Valid Title", "Valid Type", 100, true)]
//     [InlineData("Invalid@Title", "Valid Type", 100, false)]
//     [InlineData("Valid Title", "Invalid@Type", 100, false)]
//     [InlineData("Valid Title", "Valid Type", -100, false)]
//     public async Task UpdateAnExpenseAsync_WithVariousValues_ShouldOnlyUpdateWithValidValues(string title, string type, decimal amount, bool isValid)
//     {
//         // Arrange
//         var expenseId = 1;
//         var entity = new ExpenseUpdateDTO { Title = title, Type = type, Amount = amount };
//         var repositoryMock = new Mock<IExpenseRepository>();
//         if (isValid)
//         {
//             _expenseRepository.Setup(repo => repo.UpdateAnExpenseAsync(expenseId, entity)).Returns(Task.CompletedTask);
//         }
    
//         // Act
//         await _expenseService.UpdateAnExpenseAsync(expenseId, entity);
    
//         // Assert
//         _expenseRepository.Verify(repo => repo.UpdateAnExpenseAsync(expenseId, entity), isValid ? Times.Once() : Times.Never());
//     }

//     // Testing DeleteAnExpenseAsync
//     [Fact]

//     public async Task DeleteAnExpenseAsync_WithValidExpenseId_ShouldCallRepositoryDeleteOnce()
//     {
//         // Arrange
//         var expenseId = 1;
//         var _expenseRepository = new Mock<IExpenseRepository>();
//         _expenseRepository.Setup(repo => repo.DeleteAnExpenseAsync(expenseId)).Returns(Task.CompletedTask);
    
//         var _expenseService = new ExpenseService(_expenseRepository.Object);
    
//         // Act
//         await _expenseService.DeleteAnExpenseAsync(expenseId);
    
//         // Assert
//         _expenseRepository.Verify(repo => repo.DeleteAnExpenseAsync(expenseId), Times.Once());
//     }

//     // Testing AddAnExpenseAsync with valid and invalid values

//     [Theory]
//     [InlineData("Valid Title", "Valid Type", 100, true)]
//     [InlineData(" valid    Title", "Valid Type  ", 1, true)]
//     [InlineData("Invalid@Title", "Valid Type", 100, false)]
//     [InlineData("Valid Title", "Invalid@Type", 100, false)]
//     [InlineData("Valid Title", "Valid Type", -100, false)]

//     public async Task AddAnExpenseAsync_WithVariousValues_ShouldOnlyAddWithValidValues(string title, string type, decimal amount, bool isValid)
//     {
//         // Arrange
//         var entity = new ExpenseCreateDTO { Title = title, Type = type, Amount = amount };
//         var repositoryMock = new Mock<IExpenseRepository>();
//         if (isValid)
//         {
//             _expenseRepository.Setup(repo => repo.AddAnExpenseAsync(entity)).Returns(Task.CompletedTask);
//         }
    
//         // Act
//         await _expenseService.AddAnExpenseAsync(entity);
    
//         // Assert
//         _expenseRepository.Verify(repo => repo.AddAnExpenseAsync(entity), isValid ? Times.Once() : Times.Never());
//     }
// }