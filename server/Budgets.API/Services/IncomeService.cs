using Budgets.DTOs;
using Budgets.Models;
using Budgets.Data;

namespace Budgets.Services;

public class IncomeService : IBudgetService{

    private readonly IRepository _repo;
    public IncomeService (IRepository repo){
        _repo = repo;
    }

    public async Task <IEnumerable<IncomeDTO>>ListItemsAsync(){
        return await _repo.ListAsync();

    }

    public async Task <IncomeDTO> AddItemAsync (IncomeCreateDTO data){
        return await _repo.AddAsync(data);
    }

    public async Task DeleteItemsAsync(int data){
        await _repo.DeleteAsync(data);
    }

    public async Task UpdateItemAsync(int id, IncomeUpdateDTO data){
        await _repo.UpdateAsync(id, data);

    }

    public async Task <IncomeDTO> GetItemByIdAsync(int id){
        return await _repo.GetByIdAsync(id);
    }

}


