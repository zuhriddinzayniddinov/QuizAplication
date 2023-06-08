using QuizApplication.Domain.Enums;

namespace QuizApplication.Application.DataTransferObjects.Users;

public record UserForModificationDto(
    int id,
    UserRole role);