using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Application.DataTransferObjects.Authentication;
using QuizApplication.Application.DataTransferObjects.Users;
using QuizApplication.Application.Services.Authentication;
using QuizApplication.Application.Services.Users;

namespace QuizApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;
    public AccountController(IUserService userService, IAuthenticationService authenticationService)
    {
        _userService = userService;
        _authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> SignUp([FromBody]UserForCreationDto userForCreationDto)
    {
        var userDto = await this._userService
                            .CreateUserAsync(userForCreationDto);

        return Ok(userDto);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody]AuthenticationDto authenticationDto)
    {
        var tokenDto = await this._authenticationService
                            .LoginAsync(authenticationDto);

        return Ok(tokenDto);
    }
}
