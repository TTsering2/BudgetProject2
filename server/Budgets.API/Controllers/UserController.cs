using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        User result = _userService.DeleteUser(userId);
        if(result != null){
            return Accepted(result);
        }
        else{
            return BadRequest("Invalid input");

        }
    }

}
