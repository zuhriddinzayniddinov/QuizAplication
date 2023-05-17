using QuizApplication.Application.DataTransferObjects.Users;

namespace QuizApplication.Application.Services.Users;

public interface IUserService
{
    IQueryable<UserDto> RetrieveUsers();
    Task<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
    Task<UserDto> RetrieveUserByIdAsync(int userId);
    Task<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
    Task<UserDto> RemoveUserAsync(int userId);
}