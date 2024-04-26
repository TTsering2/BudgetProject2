namespace Incomes.Tests;
using Moq;
using Xunit;
using Budgets.DTOs;
using Budgets.Data;
using Budgets.Services;

public class IncomesServiceTests
{   
/// <summary>
/// not working ....comeback to tjis
/// </summary>
    private readonly Mock<IRepository> _mockRepo;
    private readonly IncomesService _service;

    public IncomesServiceTests(){
        _mockRepo = new Mock<IRepository>();
        _service = new IncomeService(_mockRepo.Object);
    }




    // testing: retrieving all incomes 
    [Fact]
    public async async getALLIncomeAsync()
    {
        //Arrange
        var expect = new List<IncomeDTO> {new IncomeDTO{Id = 1, UserName = "new user"}};
        _mockRepo.Setup(x => ListAsync()).ReturnAsync(expect);


        //act
        //calling ListItemsAsync from service class
        var res = await _service.ListItemsAsync();


        //assert
        Assert.Equal(expect, res);
        _mockRepo.Verify(x => x.ListAsync(), Times.Once);
    }




      [Fact]
    public async Task CreatingBookAsync()
    {
        // Arrange
        var incomeDto = new IncomeCreateDTO { UserName = "New user" };
        var createIncome = new IncomeDTO { Id = 1, UserName = "New user" };
        //AddAsync is from the IRepository class
        _mockRepo.Setup(x => x.AddAsync(incomeDto)).ReturnsAsync(createIncome);

        // Act
        //AddItemAsync for Income service class
        var result = await _service.AddItemAsync(incomeDto);

        // Assert
        Assert.Equal(createIncome, result);
        _mockRepo.Verify(x => x.AddAsync(bookDto), Times.Once);
    }

}


