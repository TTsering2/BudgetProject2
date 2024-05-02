using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budgets.Models;

public class User
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    public required string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
    public IEnumerable<Expense>? Expenses { get; set; }
    public IEnumerable<Income>? Incomes { get; set; }
    public IEnumerable<Stock>? Stocks { get; set; }
}
