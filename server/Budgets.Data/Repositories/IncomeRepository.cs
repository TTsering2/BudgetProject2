// using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;
using Microsoft.EntityFrameworkCore;


namespace Budgets.Data;

public class IncomeRepository : IIncomeRepository{

    private readonly BudgetsDbContext _dbContext;

    public IncomeRepository(BudgetsDbContext context){
       _dbContext = context;
    }


    // Get all Incomes for a given User 
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAsync(int userId)
    {
        IEnumerable<IncomeDTO> incomes = await _dbContext.Incomes
            .Where(i => i.UserId == userId)
            .Include(i => i.User)
            .Select(i => new IncomeDTO
            {
                //formatting 
                Id = i.Id,
                Title = i.Title,
                Type = i.Type,
                Amount = i.Amount,
                Date = i.Date,
                Username = i.User.Username
            })
            .ToListAsync();
        return incomes;
    }

    // Get income by UserId and incomeId
    public async Task<IncomeDTO>? GetIncomeByUserIdAndIncomeIdAsync(int userId, int incomeId)
    {
        IncomeDTO incomes = await _dbContext.Incomes
            .Where(i => i.UserId == userId && i.Id == incomeId)
            .Include(i => i.User)
            .Select(i => new IncomeDTO
            {   
                Id = i.Id,
                Title = i.Title,
                Type = i.Type,
                Amount = i.Amount,
                Date = i.Date,
                Username = i.User.Username
            })
            .FirstOrDefaultAsync();
        return incomes;

    }


    //Get income by UserId and income type
    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndIncomeTypeAsync(int userId, string incomeType){
        IEnumerable<IncomeDTO> incomes = await _dbContext.Incomes
            .Where(i => i.UserId == userId && i.Type == incomeType )  //checking conditions
            .Include(i => i.User)
            .Select(i => new IncomeDTO
            {   
                Id = i.Id,
                Title = i.Title,
                Type = i.Type,
                Amount = i.Amount,
                Date = i.Date,
                Username = i.User.Username
            })
            .ToListAsync();
        return incomes;
    }

    //Adding Income info to our dataase 
    public async Task AddAnIncomeAsync(IncomeCreateDTO entity){
        //creating a new instance of type Income
        Income newIncome = new Income
        {
            Title = entity.Title,
            Type = entity.Type,
            Amount = entity.Amount,
            Date = entity.Date,
            UserId = entity.UserId
        };
        _dbContext.Incomes.Add(newIncome);   //add new info to _dbcontext
        await _dbContext.SaveChangesAsync();
    }

    //deleting income by id
    public async Task DeleteAnIncomeAsync(int incomeId){

        Income income = await _dbContext.Incomes.FindAsync(incomeId);
        
        if(income == null){
            throw new Exception($"Income with ID {incomeId} not found.");
        }

        _dbContext.Incomes.Remove(income);
        await _dbContext.SaveChangesAsync();
    }

    //Updating Income Inforamtion 
    public async Task UpdatAnIncomeeAsync(int incomeId, IncomeUpdateDTO entity)
    {
        Income oldIncome = await _dbContext.Incomes
        .Include(i => i.User)                           //user information
        .FirstOrDefaultAsync(i => i.Id == incomeId );


        if(oldIncome == null)
        {
            throw new Exception($"Income with ID {incomeId} not found");
        }else{
            //check any changes from old to new 
            oldIncome.Title = entity.Title ?? oldIncome.Title;
            oldIncome.Type = entity.Type ?? oldIncome.Type;
            oldIncome.Amount = entity.Amount ?? oldIncome.Amount;
            oldIncome.Date = entity.Date ?? oldIncome.Date;
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<IncomeDTO>>? GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate){
        IEnumerable<IncomeDTO> incomes = await _dbContext.Incomes
            .Where(i => i.UserId == userId && i.Date >= startDate && i.Date <= endDate)
            .Include(i => i.User)
            .Select(i => new IncomeDTO
            {
                Title = i.Title,
                Type = i.Type,
                Amount = i.Amount,
                Date = i.Date,
                Username = i.User.Username


            })
            .ToListAsync();
        return incomes;


    }
}