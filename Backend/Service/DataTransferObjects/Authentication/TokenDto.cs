namespace QuizApplication.Application.DataTransferObjects.Authentication;

public record TokenDto(
    string name,
    string role,
    string accessToken,
    DateTime expireDate);