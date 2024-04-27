namespace Budgets.DTOs;
using Budgets.Models;


public class UserCreateDTO
{   

    public string Name { get; set; }
    public string Username { get; set; }
  
      public UserCreateDTO(string name, string username){
        Name = name;
        Username = username;
    }
}