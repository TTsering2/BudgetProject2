using System.Text.RegularExpressions;

public static class StockValidator
{
    public static bool ValidateName(string companyName){
        if(string.IsNullOrEmpty(companyName) || Regex.IsMatch(companyName, @"[!@#$%^&*]")){

            return false;
        }
        else{
           return true;
        }
    }


    public static bool ValidatePrice(double price)
    {
        return price > 0;
    }

    public static bool ValidateQuantity(int quantity)
    {
        return quantity > 0;
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