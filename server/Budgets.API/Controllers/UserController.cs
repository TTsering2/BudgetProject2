using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Mvc;
using Budgets.Services;


namespace Budgets.Controller
{

    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        // Constructor to inject IUserService dependency
        public UserController(IUserService service)
        {
            _userService = service;
        }

        
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListUsers()
        {
            try
            {
                // Return a list of users
                return Ok(_userService.ListUsers());
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
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserById(int id)
        {
            try
            {
                // Return a user by their ID
                User user = _userService.GetUserById(id);
                if(user == null){
                    return BadRequest();
                }
                else{
                    UserCreateDTO newUser = new UserCreateDTO(user.Name, user.Username);
                    return Ok(newUser);
                }

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
        [HttpGet("username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {   
                 // Return a user by their ID
                User user = _userService.GetUserByUserName(username);
                if(user == null){
                    return BadRequest();
                }
                else{
                    UserCreateDTO newUser = new UserCreateDTO(user.Name, user.Username);
                    return Ok(newUser);
                }

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
        /// <param name="user">The user to be added.</param>        
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                // Add a new user
                User result = _userService.AddUser(user);
                if (result != null)
                {
                    // Return a DTO for the created user
                    UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
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
        /// <param name="user">The user to be updated.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                // Update an existing user
                User result = _userService.UpdateUser(user);
                if (result != null)
                {
                    // Return a DTO for the updated user
                    UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
                    return Accepted(newUser);
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
        /// <param name="userId">The ID of the user to delete.</param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                // Delete a user by their ID
                bool result = _userService.DeleteUser(userId);
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
        /// Handles user login.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login(string username, string password)
        {
            try
            {
                // Validate user credentials
                bool AuthUser = _userService.ValidateUserStatus(username, password);
                if (AuthUser)
                {
                    // Return the user's ID if authenticated
                    User user = _userService.GetUserByUserName(username);
                    return Ok(new { UserId = user.Id });
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