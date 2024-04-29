using Budgets.DTOs;
using Budgets.Models;
using Microsoft.AspNetCore.Mvc;

[Route("/api/[controller]")]
public class UserController: ControllerBase
{   

    private readonly UserService _userService;
    public UserController(UserService service){
        _userService = service;
    }

    //Get All Users

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ListUsers()
    {   
        try{
            return Ok(_userService.ListUsers());
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    //Get User by Id
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserById(int id)
    {   
        try{
            return Ok(_userService.GetUserById(id));
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    
    //Get User by Username
    [HttpGet("username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserByUsername(string username)
    {   
        try{
            return Ok(_userService.GetUserByUserName(username));
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    //Create a new User
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddUser(User user){

        try{
            User result = _userService.AddUser(user);
            if(result != null){
                UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
                return Ok(newUser);
            }else{
                return BadRequest("Invalid input");
            }
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    //Update user Data
    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult UpdateUser(User user){
        User? result = _userService.UpdateUser(user);
        if(result!= null){
            UserCreateDTO newUser = new UserCreateDTO(result.Name, result.Username);
            return Accepted(newUser);
        }else{
            return BadRequest("Invalid input");
        }
    }

    //Delete User by Id
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteUser(int userId){
        try{
            bool result = _userService.DeleteUser(userId);
            if(result){
                return Accepted(result);
            }
            else{
                return BadRequest("Invalid input");
            }
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        
    }

    /*Verify user has entry in DB*/
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Login(string username, string password){
        try{
            bool AuthUser = _userService.ValidateUserStatus(username,password);
            if(AuthUser){
                User user = _userService.GetUserByUserName(username);
                return Ok(new { UserId = user.Id });
            }
            else{
                return Unauthorized();
            }
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }

    }
}
