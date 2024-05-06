namespace Budgets.Data;
using Budgets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


public class UserRepository : IUserRepository
{   
   private readonly BudgetsDbContext _dbContext;

    public UserRepository(BudgetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get all users
    public async Task<IEnumerable<User>> ListUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    // Get user by Id
    public async Task<User>? GetUserById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User>? GetUserByUsername(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
    }

    public async Task<User>? AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User>? UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User>? DeleteUser(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

}