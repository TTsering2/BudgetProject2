public interface IValidator {

    public bool ValidateUsername(string username);
    public bool ValidateName(string name);
    public bool ValidatePsw(string psw);

    public bool ValidateAgainstEscapeCharacters(string input);
    public bool ValidateUser(string username, string name, string psw);


}