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

        // Constructor to inject IUserService dependency
        public UserController(IUserService service)
        {
            _userService = service;
        }

        // GET: /api/User
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

        // GET: /api/User/id/{id}
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

        // GET: /api/User/username/{username}
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

        // POST: /api/User
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

        // PUT: /api/User
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

        // DELETE: /api/User
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

        // POST: /api/User/login
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
