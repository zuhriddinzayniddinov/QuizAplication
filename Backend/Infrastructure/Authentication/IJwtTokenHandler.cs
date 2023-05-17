using System.IdentityModel.Tokens.Jwt;
using QuizApplication.Domain.Entities.Users;

namespace QuizApplication.Infrastructure.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
}