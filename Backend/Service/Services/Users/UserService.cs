using QuizApplication.Application.DataTransferObjects.Users;
using QuizApplication.Domain.Entities.Users;
using QuizApplication.Infrastructure.Authentication;
using QuizApplication.Infrastructure.Repositories.Users;

namespace QuizApplication.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public IQueryable<UserDto> RetrieveUsers()
    {
        return this._userRepository
            .SelectAll()
            .Select(u=>UserToDto(u));
    }

    public async Task<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto)
    {
        var salt = Guid.NewGuid()
                        .ToString();

        var passwordHesh =
            this._passwordHasher
                .Encrypt(
                    userForCreationDto.Password,
                    salt);

        User user = new User()
        {
            Name = userForCreationDto.name,
            Email = userForCreationDto.email,
            Salt = salt,
            PasswordHash = passwordHesh,
            Role = userForCreationDto.role
        };

        user = await this._userRepository
            .InsertAsync(user);

        return UserToDto(user);
    }

    public async Task<UserDto> RetrieveUserByIdAsync(int userId)
    {
        var user = 
            await this._userRepository
                .SelectByIdAsync(userId);

        return UserToDto(user);
    }

    public Task<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> RemoveUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    private UserDto UserToDto(User user)
    {
        return new UserDto(
            user.Id,
            user.Name,
            user.Email,
            user.Role);
    }
}