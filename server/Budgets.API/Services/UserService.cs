using Budgets.Data;
using Budgets.DTOs;
using Budgets.Models;
using Budgets.Validators;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budgets.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _validator;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IUserValidator validator, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<IEnumerable<User>>? ListUsers()
        {
            return await _userRepository.ListUsers();
        }

        public async Task<User>? AddUser(UserCreateDTO user)
        {
            // If the user is valid and does not already exist
            if (_validator.ValidateUser(user.Username, user.Name, user.Password) && await _userRepository.GetUserByUsername(user.Username) == null)
            {
                User newUser = new User
                {
                    Username = user.Username,
                    Name = user.Name,
                    Password = user.Password
                };
                return await _userRepository.AddUser(newUser);
            }

            return null;
        }

        public async Task<User>? UpdateUser(UserUpdateDTO user)
        {
           User userToUpdate = await _userRepository.GetUserById(user.Id);
    if (userToUpdate == null)
    {
        return null;
    }

    // Update fields only if they are not null or empty in the DTO
    if (!string.IsNullOrWhiteSpace(user.Name))
    {
        userToUpdate.Name = user.Name;
    }

    if (!string.IsNullOrWhiteSpace(user.Username))
    {
        userToUpdate.Username = user.Username;
    }

    if (!string.IsNullOrWhiteSpace(user.Password))
    {
        userToUpdate.Password = user.Password;
    }

    // Validate and update user
    if (_validator.ValidateUser(userToUpdate.Username, userToUpdate.Name, userToUpdate.Password))
    {
        return await _userRepository.UpdateUser(userToUpdate);
    }

    return null;
        }

        public async Task<bool> DeleteUser(int id)
        {
            User userToDelete = await _userRepository.GetUserById(id);
            if (userToDelete != null)
            {
                await _userRepository.DeleteUser(userToDelete);
                return true;
            }
            return false;
        }

        public async Task<User>? GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User>? GetUserByUserName(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<bool> ValidateUserStatus(string username, string password)
        {
            User userToValidate = await _userRepository.GetUserByUsername(username);
            return userToValidate != null && userToValidate.Password == password;
        }
    }
}
