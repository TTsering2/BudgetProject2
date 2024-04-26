
using Budgets.DTOs;
using Budgets.Models;

public interface IUserRepository
{   
    public IEnumerable<User> ListUsers();
    public User GetUserById(int id);
    public User GetUserByUsername(string username);
    public User AddUser(User user);
    public User UpdateUser(User user);
    public User DeleteUser(User user);

}