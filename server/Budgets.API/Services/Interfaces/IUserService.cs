using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;
public interface IUserService
{

<<<<<<< HEAD
    public List<User>? ListUsers();
    public User? AddUser(User user);
    public User? UpdateUser(User user);
    public bool DeleteUser(int id);
    public User? GetUserById(int id);
    public User? GetUserByUserName(string username);
=======
    public Task<IEnumerable<User>>? ListUsers();
    public Task<User>? AddUser(UserCreateDTO user);
    public Task<User>? UpdateUser(UserUpdateDTO user);
    public Task<bool> DeleteUser(int id);
    public Task<User>? GetUserById(int id);
    public Task<User>? GetUserByUserName(string username);
>>>>>>> 4e95ea3944aa287e99e3c125d4bdab6e3134d303
    
    //Implement validation of login status
    public Task<bool> ValidateUserStatus(string username, string password);
}