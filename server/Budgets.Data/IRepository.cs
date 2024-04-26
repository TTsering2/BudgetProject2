using Budgets.Models;
using Budgets.DTOs;


namespace Budgets.Data;
/*  Interface for the Income Repo class*/
public interface IRepository{
    Task<IEnumerable<IncomeDTO>> ListAsync();
    Task<IncomeDTO> GetByIdAsync(int id);
    Task<IncomeDTO> AddAsync(IncomeCreateDTO entity);
    Task UpdateAsync(int id, IncomeUpdateDTO entity);
    Task DeleteAsync(int id);
    
}
