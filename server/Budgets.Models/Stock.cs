namespace Budgets.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Stock
{


    public int Id { get; set; }

    [Required(ErrorMessage = "Company name is required")]
    public string CompanyName { get; set; }
    public string TickerSymbol { get; set; }

    // [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }
    public int Quantity { get; set; }

    // [Required(ErrorMessage = "Quanity of stocks is required")]
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    
    public Stock(string companyName, double price, int quantity)
    {
        CompanyName = companyName;
        Price = price;
        Quantity = quantity;
        
    }

    public Stock(int id, string companyName, string TickerSymbol, double price, int quantity, int userId)
    {
        Id = id;
        CompanyName = companyName;
        this.TickerSymbol = TickerSymbol;
        Price = price;
        Quantity = quantity;
        UserId = userId;
    }

    public Stock(){}
    
}