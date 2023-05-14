using Microsoft.AspNetCore.Mvc;
using QuizAplication.Application.DataTransferObjects.Authentication;
using QuizAplication.Domain.Entities.Users;

namespace QuizAplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccauntController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody]User user)
    {
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] AuthenticationDto authenticationDto)
    {
        return Ok(authenticationDto);
    }
}
