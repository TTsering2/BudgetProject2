using System.Text.RegularExpressions;
namespace Budgets.Validators;
public class ValidatorIncome
{
     public static bool ValidateIncomeTitle(string title){
        if(Regex.IsMatch(title, @"[!@#$%^&*]") || title == "" || title == null){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateIncomeType(string type){
        if(Regex.IsMatch(type, @"[!@#$%^&*]") || type == "" || type == null){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateIncomeAmount(decimal amount){
        if(amount < 0){
           return false;
        }
        else{
           return true;
        }
    }


    public static bool ValidateAllIncome(string title, string type, decimal amount){

        if(ValidateIncomeTitle(title) && ValidateIncomeType(type) && ValidateIncomeAmount(amount)){
            return true;
        }
        else{
            return false;
        }
    }

}