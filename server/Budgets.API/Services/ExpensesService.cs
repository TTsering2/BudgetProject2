
using System.ComponentModel.DataAnnotations;
using Budgets.Models;
namespace BudgetProject2;

public class ExpensesService : IBudgetService<Expense>
{   
    private readonly IRepository<Expense> _ExpensesRepository;

    public ExpensesService (IRepository<Expense> _ExpensesRepository){
        this._ExpensesRepository = _ExpensesRepository;
    } 

    public IEnumerable<Expense> ListItems() {
        return _ExpensesRepository.List();
    }

    public Expense AddItem(Expense data){
        if(ValidatorExpenses.ValidateAll(data.Title, data.Type, data.Amount)){
            return _ExpensesRepository.Add(data);
        }
        else{
            return null;
        }

    }
    public bool DeleteItem(Expense data){
        //Find id of the expense
        Expense expenseToDelete = _ExpensesRepository.GetById(data.Id);

        if(expenseToDelete != null){
            _ExpensesRepository.Delete(expenseToDelete);
            return true;
        }
        else{
            return false;
        }
    }
    public Expense? UpdateItem(Expense data){
           Expense ExpenseToUpdate = _ExpensesRepository.GetById(data.Id);
            if(ExpenseToUpdate != null){
                if(ValidatorExpenses.ValidateAll(data.Title, data.Type, data.Amount)){
                    ExpenseToUpdate.Amount = data.Amount;
                    ExpenseToUpdate.Title = data.Title;
                    ExpenseToUpdate.Type = data.Type;
                    _ExpensesRepository.Update(ExpenseToUpdate);
                    return ExpenseToUpdate;
                }
            }

            return null;
    }


    public Expense GetItemById(int id){
        return _ExpensesRepository.GetById(id);
    }
}

