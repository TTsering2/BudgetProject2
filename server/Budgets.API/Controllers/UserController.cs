using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Mvc;
using Budgets.Services;

namespace Budgets.Controller;

[Route("/api/[controller]")]
public class UserController: ControllerBase
{   

    private readonly UserService _userService;
    public UserController(UserService service){
        _userService = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ListUsers()
    {
        return Ok(_userService.ListUsers());
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserById(int id)
    {
        return Ok(_userService.GetUserById(id));
    }

    
    [HttpGet("username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserByUsername(string username)
    {
        return Ok(_userService.GetUserByUserName(username));
    }

    [HttpPost]
    public IActionResult AddUser(User user){
        User result = _userService.AddUser(user);
        if(result != null){
            UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
            return Ok(newUser);
        }else{
            return BadRequest("Invalid input");
        }
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult UpdateUser(User user){
        User result = _userService.UpdateUser(user);
        if(result!= null){
            UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
            return Accepted(newUser);
        }else{
            return BadRequest("Invalid input");
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteUser(int userId){
        bool result = _userService.DeleteUser(userId);
        if(result){
            return Accepted(result);
        }
        else{
            return BadRequest("Invalid input");

        }
    }

    /*Verification*/
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Login(string username, string password){
    
        bool AuthUser = _userService.ValidateUserStatus(username,password);
        if(AuthUser){
            User user = _userService.GetUserByUserName(username);
            return Ok(new { UserId = user.Id });
        }
        else{
            return Unauthorized();
        }
    }
}
