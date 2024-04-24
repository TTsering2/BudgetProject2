namespace Budgets.Data;
using Budgets.Models;

public class UserRepository : IUserRepository
{   
    private readonly BudgetsDbContext _dbContext; 
    public UserRepository(BudgetsDbContext _dbContext){
        this._dbContext = _dbContext;
    }
    //Get all users
    public IEnumerable<User> ListUsers(){
        return _dbContext.Users.ToList();
    }
    //Get user by Id
    public User GetUserById(int id){
        return _dbContext.Users.Find(id);
    }
    public User GetUserByUsername(string username){
        return _dbContext.Users.Where(user => user.Username == username).FirstOrDefault();
    }
    public User AddUser(User user){
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }
    public User UpdateUser(User user){
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
        return user;
    }
    public User DeleteUser(User user){
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
        return user;

    }
}