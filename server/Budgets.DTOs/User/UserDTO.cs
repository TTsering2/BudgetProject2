using Budgets.Models;

namespace Budgets.DTOs{
  public class UserDTO
{   

    public string Name { get; set; }
    public string Username { get; set; }

  
      public UserDTO(string name, string username){
        Name = name;
        Username = username;
    }
}
}

