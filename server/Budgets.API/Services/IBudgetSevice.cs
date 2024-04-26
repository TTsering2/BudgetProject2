using Budgets.Models;
using Budgets.DTOs;

/*      Interface for Income service    */
namespace Budgets.Services;
public interface IBudgetService{
    Task <IEnumerable<IncomeDTO>>ListItemsAsync();
    Task <IncomeDTO> AddItemAsync (IncomeCreateDTO data);
    Task DeleteItemsAsync(int data);
    Task UpdateItemAsync(int id, IncomeUpdateDTO data);
    Task <IncomeDTO> GetItemByIdAsync(int id);
}