using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;
using Budgets.Services;
public class UserService : IUserService
{   
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _validator;
    //private readonly ILogger<UserService> _logger;
    public UserService(IUserRepository userRepository, IUserValidator validator){
        _userRepository = userRepository;
        _validator = validator;
        //_logger = logger;
    }
    public List<User> ListUsers(){
        return _userRepository.ListUsers().Result.ToList();
    }
    public User GetUserById(int id){
        return _userRepository.GetUserById(id).Result;
    }

    public User GetUserByUserName(string username){
        return _userRepository.GetUserByUsername(username).Result;
    }

    public User? AddUser(User user){
        //If we already have user with this name
        if(_validator.ValidateUser(user.Username, user.Name, user.Password)){
            if(_userRepository.GetUserByUsername(user.Username) == null){
                return _userRepository.AddUser(user).Result;
            }
        }

            return null;
    }
    public User? UpdateUser(User user){
        User userToUpdate = GetUserById(user.Id);
        if(userToUpdate == null){
            return null;
        }
        else{
            if(_validator.ValidateUser(user.Username, user.Name, user.Password)){
                userToUpdate.Name = user.Name;
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                 if(_userRepository.GetUserByUsername(user.Username) == null){
                    return _userRepository.UpdateUser(userToUpdate).Result;
                }
            }
            
        }

        return null;
    }
    public bool DeleteUser(int id){
        User userToDelete = _userRepository.GetUserById(id).Result;
         if(userToDelete == null){
            return false;
        }
        else{
             _userRepository.DeleteUser(userToDelete);
             return true;
        }
    }

    public bool ValidateUserStatus(string username, string password){

        User userToValidate = _userRepository.GetUserByUsername(username).Result;
        if(userToValidate != null){
            if(userToValidate.Password == password){
                return true;
            }
        }

        return false;

    }



}