using Budgets.DTOs;
using Budgets.Models;

public interface IUserService{

    public List<User> ListUsers();
    public User AddUser(User user);
    public User UpdateUser(User user);
    public User DeleteUser(User user);
    public User GetUserById(int id);
    public User GetUserByUserName(string username);
    
    //Implement validation of login status
    //public bool ValidateUserStatus(string validationToken);



}