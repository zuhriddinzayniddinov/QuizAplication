using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplication.Application.DataTransferObjects.Authentication;

namespace QuizApplication.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<TokenDto> LoginAsync(AuthenticationDto authenticationDto);
}

