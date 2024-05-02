using System.Text.RegularExpressions;

public static class StockValidator
{
    public static bool ValidateName(string companyName){
        if(companyName =="" || companyName ==null || Regex.IsMatch(companyName, @"[!@#$%^&*]")){

            return false;
        }
        else{
           return true;
        }
    }


    public static bool ValidatePrice(double price)
    {
        if(price < 0){
           return false;
        }
        else{
           return true;
        }
    }

    public static bool ValidateQuantity(int quantity)
    {
        if(quantity < 0){
           return false;
        }
        else{
           return true;
        }
    }

    public static bool ValidateAll(string companyName, double price, int quantity){

        if(ValidateName(companyName) && ValidatePrice(price) && ValidateQuantity(quantity)){
            return true;
        }
        else{
            return false;
        }
    
    }
}