using Xunit;
using Budgets.Models;

public class ExpenseTests
{

    [Theory]
    [InlineData("Meat", true)]
    //[InlineData("Apple.", false)]
    [InlineData("Apple!", false)]
    [InlineData("", false)]
    //[InlineData("     ", false)]
    //[InlineData(null, false)]
    public void ValidateTitle_ReturnsExpectedResult(string Title, bool expectedResult)
    {
        // Act
        var result = ValidatorExpenses.ValidateTitle(Title);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("Grocery", true)]
    //[InlineData("Grocery.", false)]
    [InlineData("Grocery!", false)]
    [InlineData("", false)]
    //[InlineData("     ", false)]
    //[InlineData(null, false)]
    public void ValidateType_ReturnsExpectedResult(string Type, bool expectedResult)
    {
        // Act
        var result = ValidatorExpenses.ValidateTitle(Type);

        // Assert
        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData(20, true)]
    [InlineData(78.99, true)]
    [InlineData(10000, true)]
    [InlineData(-1, false)]
    //[InlineData(null, false)]
    //[InlineData(null, false)]
    public void ValidateAmount_ReturnsExpectedResult(decimal Amount, bool expectedResult)
    {
        // Act
        var result = ValidatorExpenses.ValidateAmount(Amount);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    // [Fact]
    // public void Model_Initialization_Fails_When_Variable_Is_Empty()
    // {
    //     // Arrange
    //     string requiredVariable = "";

    //     // Act & Assert
    //     Assert.Throws<ArgumentException>(() => new YourModel(requiredVariable));
    // }

    // [Fact]
    // public void User_WithEmptyTitle_ShouldThrowException()
    // {
        // Arrange
        //var expense = new Expense();
        
        // Act & Assert
        //Assert.Throws<ArgumentNullException>(() => expense.Title = null);
        //Assert.Throws<ArgumentNullException>(() => expense.Title = "");
        //Assert.Throws<ArgumentNullException>(() => expense.Title = "  "); // Ensure whitespace-only titles are not allowed
    //}

    

    [Fact]
    public void User_WithValidTitleAndAmount_ShouldNotThrowException()
    {
        // Arrange
        var expense = new Expense();

        // Act & Assert
        Assert.NotNull(expense.Title = "meat");
        Assert.NotNull(expense.Amount = 20);
    }
}