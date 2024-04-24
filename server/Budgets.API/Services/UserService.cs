using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;

public class UserService
{   
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository){
        _userRepository = userRepository;
    }
    public List<User> ListUsers(){
        return _userRepository.ListUsers().ToList();
    }
    public User GetUserById(int id){
        return _userRepository.GetUserById(id);
    }

    public User GetUserByUserName(string username){
        return _userRepository.GetUserByUsername(username);
    }

    public User? AddUser(User user){
        //If we already have user with this name
        if(GetUserByUserName(user.Username) != null){
            return null;
        }
        else{
            return _userRepository.AddUser(user);
        }

    }
    public User? UpdateUser(User user){
        if(GetUserById(user.Id) == null){
            return null;
        }
        else{
            return _userRepository.UpdateUser(user);
        }
    }
    public User? DeleteUser(User user){
         if(GetUserById(user.Id) == null){
            return null;
        }
        else{
            return _userRepository.DeleteUser(user);
        }
    }


}