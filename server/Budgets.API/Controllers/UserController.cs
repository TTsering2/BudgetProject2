using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Budgets.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budgets.Controller
{
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor to inject IUserService dependency.
        /// </summary>
        /// <param name="service">The IUserService implementation.</param>
        public UserController(IUserService service)
        {
            _userService = service;
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>An IActionResult representing the list of users.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListUsers()
        {
            try
            {
                IEnumerable<User> userList = await _userService.ListUsers();
                if (userList == null || !userList.Any())
                {
                    return NotFound("No users found");
                }
                // Return a list of users
                return Ok(userList);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while listing users: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

           /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns an IActionResult representing the retrieved user.</returns>
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                UserDTO user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("No user with such ID was found");
                }
                // Return a user by their ID
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while getting user by ID: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

          /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>Returns an IActionResult representing the retrieved user.</returns>
        [HttpGet("username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            try
            {
                UserDTO user = await _userService.GetUserByUserName(username);
                if (user == null)
                {
                    return NotFound("No user with such username was found");
                }
                // Return a user by their username
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while getting user by username: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        
        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user object containing the information of the new user.</param>
        /// <returns>Returns an IActionResult representing the newly created user.</returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                // Add a new user
                UserDTO newUser = await _userService.AddUser(user);
                if (newUser != null)
                {
                    // Return a DTO for the created user
                    return Ok(newUser);
                }
                else
                {
                    return BadRequest("Invalid input");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while adding user: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


           /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user object containing updated information.</param>
        /// <returns>Returns an IActionResult representing the updated user.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                // Update an existing user
                UserDTO updatedUser = await _userService.UpdateUser(user);
                if (updatedUser != null)
                {
                    // Return a DTO for the updated user
                    return Accepted(updatedUser);
                }
                else
                {
                    return BadRequest("Invalid input");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while updating user: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

       /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to be deleted.</param>
        /// <returns>Returns an IActionResult indicating the result of the deletion operation.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                // Delete a user by their ID
                bool result = await _userService.DeleteUser(userId);
                if (result)
                {
                    return Accepted(result);
                }
                else
                {
                    return BadRequest("Invalid input");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while deleting user: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>Returns the user's username upon successful login.</returns>        
         [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                // Validate user credentials
                bool AuthUser = await _userService.ValidateUserStatus(username, password);
                if (AuthUser)
                {
                    // Return the user's ID if authenticated
                    UserDTO user = await _userService.GetUserByUserName(username);
                    return Ok(new { user = user.Username });
                }
                else
                {
                    // Return Unauthorized status if authentication fails
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while logging in: {ex}");
                // Return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
