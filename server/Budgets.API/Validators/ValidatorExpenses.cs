using System.Text.RegularExpressions;

public class ValidatorExpenses
{
     public static bool ValidateTitle(string title){
        if(Regex.IsMatch(title, @"[!@#$%^&*]") || title == "" || title == null){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateType(string type){
        if(Regex.IsMatch(type, @"[!@#$%^&*]") || type == "" || type == null){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateAmount(decimal amount){
        if(amount < 0){
           return false;
        }
        else{
           return true;
        }
    }


    public static bool ValidateAll(string title, string type, decimal amount){

        if(ValidateTitle(title) && ValidateType(type) && ValidateAmount(amount)){
            return true;
        }
        else{
            return false;
        }
    }

}