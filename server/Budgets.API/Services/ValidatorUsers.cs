using System.Text.RegularExpressions;

public class ValidatorUsers : IValidator {

   public ValidatorUsers(){}
    public bool ValidateUsername(string username){

       if (!ValidateAgainstEscapeCharacters(username)){
        return true;
       }
       else{
        return false;
       }
       
    }

    public bool ValidateName(string name){
        if(!ValidateAgainstEscapeCharacters(name)){
            return true;
        }
        return false;
    }
    public bool ValidatePsw(string psw){
        if(psw.Length < 8){
            return false;
        }
        else{
            return true;
        }
    }

    public bool ValidateUser(string username, string name, string psw){
        bool isNameValid = ValidateName(name);
        bool isUserNameValid = ValidateUsername(username);
        bool isPswValid = ValidatePsw(psw);
    
        if(isNameValid && isUserNameValid && isPswValid){

           return true;

        }
        return false;
    }


    public bool ValidateAgainstEscapeCharacters(string input){

        string regex = @"[!@#$%^&*]";
        return Regex.IsMatch(input, regex);
    }

}