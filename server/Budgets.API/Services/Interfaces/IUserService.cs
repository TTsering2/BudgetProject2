using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;
public interface IUserService
{

    public Task<IEnumerable<User>>? ListUsers();
    public Task<User>? AddUser(UserCreateDTO user);
    public Task<User>? UpdateUser(UserUpdateDTO user);
    public Task<bool> DeleteUser(int id);
    public Task<User>? GetUserById(int id);
    public Task<User>? GetUserByUserName(string username);
    
    //Implement validation of login status
    public Task<bool> ValidateUserStatus(string username, string password);
}