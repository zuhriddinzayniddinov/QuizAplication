using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.DataTransferObjects.Users;
using QuizApplication.Application.Services.Users;

namespace QuizApplication.Api.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        return Ok(this._userService.RetrieveUsers());
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetByIdUsersAsync(int userId)
    {
        var userDto = await this._userService.RetrieveUserByIdAsync(userId);
        return Ok(userDto);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditUserRole([FromBody]UserForModificationDto userForModification)
    {
        var userDto = await this._userService.ModifyUserAsync(userForModification);
        return Ok(userDto);
    }
}