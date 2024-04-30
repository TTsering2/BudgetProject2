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

    } // Get all users asynchronously
    public async Task<IEnumerable<User>> ListUsers()
    {
        return await _userRepository.ListUsers();
    }

    // Get user by Id asynchronously
    public async Task<UserDTO> GetUserById(int id)
    {   
        User newUser = await _userRepository.GetUserById(id);
        UserDTO newUserDTO = new UserDTO(newUser.Name, newUser.Username);
        return newUserDTO;
    }

    // Get user by username asynchronously
    public async Task<UserDTO> GetUserByUserName(string username)
    {   
        User newUser =  await _userRepository.GetUserByUsername(username);
        UserDTO newUserDTO = new UserDTO(newUser.Name, newUser.Username);
        return newUserDTO;
    }

    // Add a user asynchronously
    public async Task<UserDTO?> AddUser(User user)
    {
        // If we already have a user with this name
        if (_validator.ValidateUser(user.Username, user.Name, user.Password))
        {
            if (await _userRepository.GetUserByUsername(user.Username) == null)
            {   
                User newUser = await _userRepository.AddUser(user);
                UserDTO newUserDTO = new UserDTO(newUser.Name, newUser.Username);
                return  newUserDTO;
            }
        }

        return null;
    }

    // Update a user asynchronously
    public async Task<UserDTO?> UpdateUser(User user)
    {
        User userToUpdate = await _userRepository.GetUserById(user.Id);
        if (userToUpdate == null)
        {
            return null;
        }
        else
        {
            if (_validator.ValidateUser(user.Username, user.Name, user.Password))
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                if (await _userRepository.GetUserByUsername(user.Username) == null)
                {   
                    User updatedUser =  await _userRepository.UpdateUser(userToUpdate);
                    UserDTO newUserDTO = new UserDTO(updatedUser.Name, updatedUser.Username);
                    return  newUserDTO;
                }
            }
        }

        return null;
    }

    // Delete a user asynchronously
    public async Task<bool> DeleteUser(int id)
    {
        User userToDelete = await _userRepository.GetUserById(id);
        if (userToDelete == null)
        {
            return false;
        }
        else
        {
            await _userRepository.DeleteUser(userToDelete);
            return true;
        }
    }

    // Validate user status asynchronously
    public async Task<bool> ValidateUserStatus(string username, string password)
    {
        User userToValidate = await _userRepository.GetUserByUsername(username);
        if (userToValidate != null && userToValidate.Password == password)
        {
            return true;
        }

        return false;
    }

}