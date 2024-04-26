namespace Budgets.Data;

using Budgets.Models;



public class ExpenseRepo : IRepository<Expense>
{
    
 private readonly BudgetsDbContext _dbContext;

 public ExpenseRepo(BudgetsDbContext context){
    this._dbContext = context;
 }

   // List all expenses
    public IEnumerable<Expense> List(){

        return _dbContext.Expenses.ToList();
    }

    // Add expense
    public Expense Add(Expense expense)
    {   
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
            return expense;
    }

    // Delete expense

        public void Delete(Expense expense)
    {
            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();
    }

    //Update expense

        public void Update(Expense expense)
    {   
        _dbContext.Expenses.Update(expense);
        _dbContext.SaveChanges();
    }

    //Get expense by id
    public Expense GetById(int id)
    {
        return _dbContext.Expenses.Find(id);
    }

}
