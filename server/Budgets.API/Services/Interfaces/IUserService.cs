using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;
public interface IUserService
{

    public List<User>? ListUsers();
    public User? AddUser(User user);
    public User? UpdateUser(User user);
    public bool DeleteUser(int id);
    public User? GetUserById(int id);
    public User? GetUserByUserName(string username);
    
    //Implement validation of login status
    public bool ValidateUserStatus(string username, string password);
}