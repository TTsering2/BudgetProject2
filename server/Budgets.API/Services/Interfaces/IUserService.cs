using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;
public interface IUserService
{

    public Task<IEnumerable<User>> ListUsers();
    public Task<UserDTO> AddUser(User user);
    public Task<UserDTO> UpdateUser(User user);
    public Task<bool> DeleteUser(int id);
    public Task<UserDTO> GetUserById(int id);
    public Task<UserDTO> GetUserByUserName(string username);
    
    //Implement validation of login status
    public  Task<bool> ValidateUserStatus(string username, string password);
}