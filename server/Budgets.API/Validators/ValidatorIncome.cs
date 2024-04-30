using System.Text.RegularExpressions;
namespace Budgets.Validators;
public class ValidatorIncome
{
        // Method to validate the income title
        // Returns true if the title is not null, empty, or containing special characters
     public static bool ValidateIncomeTitle(string title){
        if(Regex.IsMatch(title, @"[!@#$%^&*]") || title == "" || title == null){
            return false;
        }
        else{
           return true;

        }
    }

    // Method to validate the income type
    // Returns true if the type is not null, empty, or containing special characters
    public static bool ValidateIncomeType(string type){
        if(Regex.IsMatch(type, @"[!@#$%^&*]") || type == "" || type == null){
            return false;
        }
        else{
           return true;

        }
    }

    // Method to validate the income amount
    // Returns true if the amount is non-negative
    public static bool ValidateIncomeAmount(decimal amount){
        if(amount < 0){
           return false;
        }
        else{
           return true;
        }
    }

// Method to validate all income-related data
        // Returns true if all income data (title, type, and amount) are valid
    public static bool ValidateAllIncome(string title, string type, decimal amount){

        if(ValidateIncomeTitle(title) && ValidateIncomeType(type) && ValidateIncomeAmount(amount)){
            return true;
        }
        else{
            return false;
        }
    }

}