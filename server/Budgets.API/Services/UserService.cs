using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;
using Budgets.Validators;

namespace Budgets.Services;
public class UserService : IUserService
{   
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _validator;

    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, IUserValidator validator,  ILogger<UserService> logger){
        _userRepository = userRepository;
        _validator = validator;
        _logger = logger;

    }
    public List<User>? ListUsers(){
        return _userRepository.ListUsers().ToList();
    }
    public User? GetUserById(int id){
        return _userRepository.GetUserById(id);
    }

    public User? GetUserByUserName(string username){
        return _userRepository.GetUserByUsername(username);
    }

    public User? AddUser(User user){
        //If we already have user with this name
        if(_validator.ValidateUser(user.Username, user.Name, user.Password)){
            if(_userRepository.GetUserByUsername(user.Username) == null){
                return _userRepository.AddUser(user);
            }
        }

            return null;
    }
    public User? UpdateUser(UserDTO user){
        User userToUpdate = GetUserById(user.Id);
        if(userToUpdate == null){
            return null;
        }
        else{

                userToUpdate.Name = user.Name ?? userToUpdate.Name;
                userToUpdate.Username = user.Username ?? userToUpdate.Username;
                userToUpdate.Password = user.Password ?? userToUpdate.Password;

                if(_validator.ValidateUser(userToUpdate.Username, userToUpdate.Name, userToUpdate.Password)){
                    if(_userRepository.GetUserByUsername(userToUpdate.Username) == null || userToUpdate.Username == user.Username){
                        return _userRepository.UpdateUser(userToUpdate);
                    }
                }

        }

        return null;
    }
    public bool DeleteUser(int id){
        User userToDelete = _userRepository.GetUserById(id);
         if(userToDelete == null){
            return false;
        }
        else{
             _userRepository.DeleteUser(userToDelete);
             return true;
        }
    }

    public bool ValidateUserStatus(string username, string password){

        User userToValidate = _userRepository.GetUserByUsername(username);
        if(userToValidate != null){
            if(userToValidate.Password == password){
                return true;
            }
        }

        return false;

    }



}