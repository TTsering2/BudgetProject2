using Budgets.Models;
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
}
