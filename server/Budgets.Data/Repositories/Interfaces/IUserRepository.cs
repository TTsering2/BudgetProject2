
using Budgets.DTOs;
using Budgets.Models;
using System.Threading.Tasks;

namespace Budgets.Data;

public interface IUserRepository
{   
    public Task<IEnumerable<User>>? ListUsers();
    public Task<User>? GetUserById(int id);
    public Task<User>? GetUserByUsername(string username);
    public Task<User>? AddUser(User user);
    public Task<User>? UpdateUser(User user);
    public Task<User>? DeleteUser(User user);
}