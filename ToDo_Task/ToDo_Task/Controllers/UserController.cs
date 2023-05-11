using Microsoft.AspNetCore.Mvc;
using ToDo_Task_Service.DataTransferObjects.Users;
using ToDo_Task_Service.IContracts;

namespace ToDo_Task.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserSaveDto model)
        => Ok(await _userService.Login(model));

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserSaveDto model)
        => Ok(await _userService.Register(model));
}