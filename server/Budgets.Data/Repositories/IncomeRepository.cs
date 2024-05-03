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
        // Query the database for incomes
        IEnumerable<IncomeDTO> incomes = await _dbContext.Incomes
            .Where(i => i.UserId == userId)         // Filter by user ID
            .Include(i => i.User)                   // Include related user information
            .Select(i => new IncomeDTO              // Project each income to an IncomeDTO object
            {
                //formatting 
                Id = i.Id,
                Title = i.Title,
                Type = i.Type,
                Amount = i.Amount,
                Date = i.Date,
                Username = i.User.Username
            })
            .ToListAsync();                         // Execute the query and return results as a list
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

        // Create a new Income entity with the provided data
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

        // Find the income entity in the database by income ID
        Income income = await _dbContext.Incomes.FindAsync(incomeId);
        
        if(income == null){
            throw new Exception($"Income with ID {incomeId} not found.");
        }

        _dbContext.Incomes.Remove(income);
        await _dbContext.SaveChangesAsync();
    }

    //Updating Income Inforamtion 
    public async Task UpdateAnIncomeAsync(int incomeId, IncomeUpdateDTO entity)
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

    public async Task<IEnumerable<IncomeDTO>> GetIncomeByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate){
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