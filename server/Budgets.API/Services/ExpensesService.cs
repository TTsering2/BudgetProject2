
using System.ComponentModel.DataAnnotations;

namespace budgettracker;
public class ExpensesService : IBudgetService<Expenses>
{   
    private readonly IRepository<Expenses> _ExpensesRepository;

    public ExpensesService (IRepository<Expenses> _ExpensesRepository){
        this._ExpensesRepository = _ExpensesRepository;
    }

    public IEnumerable<Expenses> ListItems() {
        return _ExpensesRepository.List();
    }

    public Expenses AddItem(Expenses data){
        if(Validator.ValidateAll(data.Name, data.Type, data.Amount)){
            return _ExpensesRepository.Add(data);
        }
        else{
            return null;
        }

    }
    public bool DeleteItem(Expenses data){
        //Find id of the expense
        Expenses expenseToDelete = _ExpensesRepository.GetById(data.ExpenseId);

        if(expenseToDelete != null){
            _ExpensesRepository.Delete(expenseToDelete);
            return true;
        }
        else{
            return false;
        }
    }
    public Expenses? UpdateItem(Expenses data){
           Expenses ExpenseToUpdate = _ExpensesRepository.GetById(data.ExpenseId);
            if(ExpenseToUpdate != null){
                if(Validator.ValidateAll(data.Name, data.Type, data.Amount)){
                    ExpenseToUpdate.Amount = data.Amount;
                    ExpenseToUpdate.Name = data.Name;
                    ExpenseToUpdate.Type = data.Type;
                    _ExpensesRepository.Update(ExpenseToUpdate);
                    return ExpenseToUpdate;
                }
            }

            return null;
    }


    public Expenses GetItemById(int id){
        return _ExpensesRepository.GetById(id);
    }
}

