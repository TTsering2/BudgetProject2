using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Budgets.Services;

namespace Budgets.Controller;

/// <summary>
/// Controller for managing user-related operations.
/// </summary>
[Route("/api/[controller]")]
public class UserController: ControllerBase
{   

    private readonly IUserService _userService;
    public UserController(IUserService service){
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
            return Ok(_userService.ListUsers());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserById(int id)
    {
        try
        {
            return Ok(_userService.GetUserById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    [HttpGet("username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserByUsername(string username)
    {
        try
        {
            return Ok(_userService.GetUserByUserName(username));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Adds a new user.
    /// </summary>
    /// <param name="user">The user object to add.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddUser(User user)
    {
        try
        {
            User result = _userService.AddUser(user);
            if (result != null)
            {
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
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Updates user data.
    /// </summary>
    /// <param name="user">The updated user object.</param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult UpdateUser(User user)
    {
        User? result = _userService.UpdateUser(user);
        if (result != null)
        {
            UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
            return Accepted(newUser);
        }
        else
        {
            return BadRequest("Invalid input");
        }
    }

    /// <summary>
    /// Deletes a user by their identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user to delete.</param>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
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
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Validates user credentials and returns user information upon successful authentication.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Login(string username, string password)
    {
        try
        {
            bool AuthUser = _userService.ValidateUserStatus(username, password);
            if (AuthUser)
            {
                User user = _userService.GetUserByUserName(username);
                return Ok(new { UserId = user.Id });
            }
            else
            {
                return Unauthorized();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
