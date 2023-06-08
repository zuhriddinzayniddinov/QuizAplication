using QuizApplication.Domain.Enums;

namespace QuizApplication.Application.DataTransferObjects.Users;


public record UserDto(
    int id,
    string name,
    string email,
    UserRole role);