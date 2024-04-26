using Budgets.Data;
using Budgets.Models;
using Moq;

namespace Budgets.Tests;

public class UserTests
{   

    //Test Validator
    [Theory]
    [InlineData("%^&", "^&*", "$%^", false)]
    [InlineData("Vlada", "vharania", "456567678", true)]
    [InlineData("^&*",  "vharania", "456567678", false)]
    [InlineData("Vlada", "^&*", "456567678", false)]
    [InlineData("Vlada", "vharania", "$%^", false)]
    public void TestValidatorCheckUser(string name, string username, string password, bool result){
        
        ValidatorUsers validator = new ValidatorUsers();
        bool validated = validator.ValidateUser(username, name,password);
        Assert.Equal(result, validated);
    }

    //Get 
      //Test summary information
    [Fact]
    public void GetAllUsersTest()
    {
        //Arrange
        Mock <IUserRepository> Repo = new Mock<IUserRepository>();

        //Create fake data 
        IEnumerable<User> MockUsers = [
            new User
            {
                Id = 1,
                Name = "Vlada Haranina",
                Username = "Vharanina",
                Password = "456456",
            },
            new User
            {
                Id = 2,
                Name = "Kelly Smith",
                Username = "KSmith",
                Password = "12345678",
            },
        ];

        Repo.Setup(Repo => Repo.ListUsers()).Returns(MockUsers);
        ValidatorUsers validator = new ValidatorUsers();
        UserService service = new UserService(Repo.Object, validator);

        //Act
        IEnumerable<User> users = service.ListUsers();

        //Assert

        Assert.Equal(2, users.Count());
        Repo.Verify(Repo => Repo.ListUsers(), Times.Exactly(1));
    }

//Test Adding user
[Theory]
[InlineData("Vlada", "vladah", "9876", false)]
[InlineData("Vlada", "duplicateusername", "98765689", false)]
[InlineData("$%^B", "vladah", "987568856", false)]
[InlineData("Vlada", "^&*ftest", "9876", false)]
public void TestAddUser(string name, string username, string psw, bool result)
{
    // Arrange
    List<User> existingUsers = new List<User>
    {
        new User
        {
            Name = "Vlada",
            Username = "duplicateusername",
            Password = "45656456"
        }
    };

    Mock<IUserRepository> Repo = new Mock<IUserRepository>();
    ValidatorUsers validator = new ValidatorUsers();

    User newUserToAdd = new User

    {   
        Name = name,
        Username = username,
        Password = psw,
        Expenses = null,
        Incomes = null,
        Stocks = null
    };

    // Setup GetUserByUsername to return existing user if username is duplicate
    Repo.Setup(repo => repo.GetUserByUsername(It.IsAny<string>()))
        .Returns<string>(inputUsername => existingUsers.FirstOrDefault(u => u.Username.Equals(inputUsername, StringComparison.OrdinalIgnoreCase)));

    UserService service = new UserService(Repo.Object, validator);
    User? addedUser = service.AddUser(newUserToAdd);

    if (result)
    {
        Assert.NotNull(addedUser);
        Repo.Verify(repo => repo.AddUser(newUserToAdd), Times.Once); // Verify that AddUser was called once
    }
    else
    {
        Assert.Null(addedUser);
        Repo.Verify(repo => repo.AddUser(newUserToAdd), Times.Never); // Verify that AddUser was not called
    }
}



    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(null, false)]
    public void TestDeleteUser(int id, bool result){
        Mock <IUserRepository> Repo = new Mock<IUserRepository>();
        ValidatorUsers validator = new ValidatorUsers();  
         //Create fake data 
        User currentUser = new User{        
            Id = 1,
            Name = "Vlada",
            Username = "vladaha",
            Password = "456456756"
        };

        int UserIdToDelete = id;

Repo.Setup(repo => repo.GetUserById(It.IsAny<int>()))
    .Returns<int>(id => id == currentUser.Id ? currentUser : null);
        UserService service = new UserService(Repo.Object, validator);

       bool deletedUser = service.DeleteUser(UserIdToDelete);
    Assert.Equal(result, deletedUser);

    }


[Theory]
[InlineData(8,"$%^B", "vladah", "987568856", false)]
[InlineData(1,"Vlada", "vladah", "9876", false)]
[InlineData(1,"Vlada", "%^nij", "9876", false)]
[InlineData(2,"Vlada", "vladah", "98456789076", false)]

    public void TestEditUser(int id, string name, string username, string psw, bool result){

    Mock<IUserRepository> Repo = new Mock<IUserRepository>();
    ValidatorUsers validator = new ValidatorUsers();

    User currentUser = new User{        
        Id = 1,
        Name = "Vlada",
        Username = "vladaha",
        Password = "456456756"
    };

    User editedUser = new User{        
        Id = id,
        Name = name,
        Username = username,
        Password = psw
    };

        _ = Repo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns<int>(id => id == currentUser.Id ? currentUser : null);
    UserService service = new UserService(Repo.Object, validator);
    User UpdatedUser = service.UpdateUser(editedUser);

    if(result){
        Assert.NotNull(UpdatedUser);
        Repo.Verify(repo => repo.UpdateUser(editedUser), Times.Once); // Verify that UpdateUser was called once
    }
    else{
        Assert.Null(UpdatedUser);
        Repo.Verify(repo => repo.UpdateUser(editedUser), Times.Never);
    }
}
}