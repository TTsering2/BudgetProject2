using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Budgets.Data;

public class IncomeRepo : IIncomeRepository{

    private readonly BudgetsDbContext _dbContext;

    public IncomeRepo(BudgetsDbContext context){
        this._dbContext = context;
    }



    public async Task<IEnumerable<IncomeDTO>> ListAsync(){
        List<IncomeDTO> income = await _dbContext.Incomes
            .Include(i => i.User)
            .Select(i => new IncomeDTO
            {
                Id = i.Id,
                UserName = i.User.Name,
                Type = i.Type,
                Title = i.Title,
                Amount = i.Amount
            })
            .ToListAsync();
        return income;   
    }



    public async Task<IncomeDTO> GetByIdAsync(int id){
        IncomeDTO income = await _dbContext.Incomes
        .Where(i => i.Id == id)
        .Include(i =>i.User)
        .Select(i => new IncomeDTO
        {
            Id = i.Id,
            UserName = i.User.Name,
            Type = i.Type,
            Title = i.Title,
            Amount = i.Amount
        })
        .FirstOrDefaultAsync();

        return income;
    }



    public async Task<IncomeDTO> AddAsync(IncomeCreateDTO entity){
        User user = await _dbContext.Users
        .FirstOrDefaultAsync(a => a.Name == entity.UserName)
        ?? new User {Name = entity.UserName};

        Income newincome = new Income
        {
            //UserName = user,
            Type = entity.Type,
            Title = entity.Title,
            Amount = entity.Amount
        };
        _dbContext.Incomes.Add(newincome);
        await _dbContext.SaveChangesAsync();

        return new IncomeDTO
        {
            Id = newincome.Id,
            UserName = newincome.User.Name,
            Type = newincome.Type,
            Title = newincome.Title,
            Amount = newincome.Amount,
        };
    }



    public async Task UpdateAsync(int id, IncomeUpdateDTO entity){
        Income income = await _dbContext.Incomes
            .Include(i => i.User)
            .FirstOrDefaultAsync(i => i.Id == id);

            if(income == null)
            {
                throw new Exception($"Income with ID {id} not found.");
            }

            if(!string.IsNullOrEmpty(entity.Type)){
                income.Type = entity.Type;
            }


            if(!string.IsNullOrEmpty(entity.Title)){
                income.Title = entity.Title;
            }

/*
            if(decimal.TryParse(entity.Amount, out decimal amount)){
                income.Amount = amount;
            }
*/
    if(!string.IsNullOrEmpty(entity.UserName) && income.User?.Name != entity.UserName)
    {
        User existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == entity.UserName);
        if(existingUser == null)
        {
            existingUser = new User{Name = entity.UserName};
            _dbContext.Users.Add(existingUser);
        }
        income.User = existingUser;
    }
    await _dbContext.SaveChangesAsync();
    }



    public async Task DeleteAsync(int id){
        Income income = await _dbContext.Incomes.FindAsync(id);

        if(income == null)
        {
            return;
        }
        _dbContext.Incomes.Remove(income);
        await _dbContext.SaveChangesAsync();
    }




}