using QuizApplication.Domain.Enums;

namespace QuizApplication.Application.DataTransferObjects.Users;

public record UserForCreationDto(
    string name,
    string email,
    string Password,
    UserRole role = UserRole.User);